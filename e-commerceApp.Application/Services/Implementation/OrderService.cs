using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stripe;
using Stripe.Checkout;

namespace e_commerceApp.Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly EcommDbContext _ecommDbContext;
        private readonly ILogger<OrderService> _logger;

        public OrderService(EcommDbContext ecommDbContext, ILogger<OrderService> logger)
        {
            _ecommDbContext = ecommDbContext;
            _logger = logger;
        }
     
        public async Task<List<OrderHeader>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _ecommDbContext.OrderHeaders.Include(u => u.User).Include(u => u.OrderDetails).ThenInclude(u => u.Product).ToListAsync();
            if (userRole != "Admin")
            {
                orders = orders.Where(u => u.UserId == userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var user = await _ecommDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId); 

            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            var order = new OrderHeader()
            {
                UserId = userId,
                OrderDate = DateTime.Now,  
                PaymentDate = DateTime.Now, 
                OrderStatus = Initials.StatusPending,  
                PaymentStatus = Initials.PaymentStatusPending,  
                PhoneNumber = user.PhoneNumber ?? "",  
                StreetAddress = user.Address ?? "",  
                Name = user.FirstName + " " + user.LastName,  
                TotalPrice = items.Sum(i => i.Product.Price * i.Count),
            };

            await _ecommDbContext.OrderHeaders.AddAsync(order);
            await _ecommDbContext.SaveChangesAsync(); 

            foreach (var item in items)
            {
                var orderItem = new OrderDetail()
                {
                    Count = item.Count,  
                    ProductId = item.Product.Id,  
                    OrderHeaderId = order.Id,  
                    Price = item.Product.Price  
                };
                await _ecommDbContext.OrderDetails.AddAsync(orderItem);
            }
            await _ecommDbContext.SaveChangesAsync();
        }


        public async Task<string> CreateStripeCheckoutSessionAsync(string orderId)
        {
            var orderHeader = await _ecommDbContext.OrderHeaders.Include(u => u.User).FirstOrDefaultAsync(u => u.Id == orderId);

            if (orderHeader == null)
            {
                _logger.LogError("Order not found with ID: {OrderId}", orderId);
                throw new Exception("Order not found.");
            }

            var orderDetail = await _ecommDbContext.OrderDetails
                .Where(u => u.OrderHeaderId == orderHeader.Id)
                .Include(u => u.Product)
                .ToListAsync();

            var domain = "https://localhost:44300/";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"admin/order/PaymentConfirmation?orderHeaderid={orderHeader.Id}",
                CancelUrl = domain + $"admin/order/details?orderId={orderHeader.Id}",
            };

            foreach (var item in orderDetail)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * 100), 
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Title
                        },
                    },
                    Quantity = item.Count,
                };
                options.LineItems.Add(sessionLineItem);
            }

            try
            {
                var service = new SessionService();
                Session session = await service.CreateAsync(options);

                UpdateStripePaymentID(orderHeader.Id, session.Id, session.PaymentIntentId);
                await _ecommDbContext.SaveChangesAsync();

                return session.Url; 
            }
            catch (StripeException ex)
            {
                _logger.LogError($"Stripe error: {ex.Message}");
                throw new Exception("Error creating Stripe session.");
            }
        }

        public async Task<string> PaymentConfirmation(string orderHeaderid)
        {
            var orderHeader = await _ecommDbContext.OrderHeaders.FirstOrDefaultAsync(u => u.Id == orderHeaderid);
            if (orderHeader!.PaymentStatus == Initials.PaymentStatusDelayedPayment)
            {
                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);
                if (session.PaymentStatus.ToLower() == "paid")
                {
                    UpdateStatus(orderHeaderid, orderHeader.OrderStatus!, Initials.PaymentStatusApproved);
                    await _ecommDbContext.SaveChangesAsync();
                }
            }
            return orderHeaderid;
        }
        public async Task<bool> CancelOrderAsync(string orderId)
        {
            var orderHeader = await _ecommDbContext.OrderHeaders.AsNoTracking().FirstOrDefaultAsync(u => u.Id == orderId);
            if (orderHeader == null)
                return false; 

            if (orderHeader.PaymentStatus == Initials.PaymentStatusApproved)
            {
                var options = new RefundCreateOptions
                {
                    Reason = RefundReasons.RequestedByCustomer,
                    PaymentIntent = orderHeader.PaymentGuidentId
                };
                var service = new RefundService();
                try
                {
                    Refund refund = service.Create(options); 

                    UpdateStatus(orderHeader.Id, Initials.StatusCancelled, Initials.StatusRefunded);
                }
                catch (StripeException ex)
                {
                    _logger.LogInformation(ex.Message);
                    return false;
                }
            }
            else
            {
                UpdateStatus(orderHeader.Id, Initials.StatusCancelled, Initials.StatusCancelled);
            }
            await _ecommDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> StartProcessingOrderAsync(string orderId)
        {
            var orderHeader = await _ecommDbContext.OrderHeaders.FirstOrDefaultAsync(u => u.Id == orderId);

            if (orderHeader == null)
            {
                return false; 
            }
            orderHeader.OrderStatus = Initials.StatusInProcess;
            _ecommDbContext.OrderHeaders.Update(orderHeader);

            await _ecommDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ShipOrderAsync(string orderId, string trackingNumber, string carrier)
        {
            var orderHeader = await _ecommDbContext.OrderHeaders.FirstOrDefaultAsync(u => u.Id == orderId);

            if (orderHeader == null)
            {
                return false; 
            }
            orderHeader.TrackingNumber = trackingNumber;
            orderHeader.Carrier = carrier;
            orderHeader.OrderStatus = Initials.StatusShipped;
            orderHeader.ShippingDate = DateTime.Now;

            if (orderHeader.PaymentStatus == Initials.PaymentStatusDelayedPayment)
            {
                orderHeader.PaymentDueDate = DateTime.Now.AddDays(30);
            }
            _ecommDbContext.OrderHeaders.Update(orderHeader);
            await _ecommDbContext.SaveChangesAsync();
            return true;
        }
        private void Update(OrderHeader obj)
        {
            _ecommDbContext.OrderHeaders.Update(obj);
        }

        private void UpdateStatus(string id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _ecommDbContext.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (paymentStatus != null)
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        private void UpdateStripePaymentID(string id, string sessionId, string paymentItentId)
        {
            var orderFromDb = _ecommDbContext.OrderHeaders.FirstOrDefault(u => u.Id == id);
            orderFromDb!.PaymentDate = DateTime.Now;
            orderFromDb.SessionId = sessionId;
            orderFromDb.PaymentGuidentId = paymentItentId;
        }

        //public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        //{
        //    var orders = await _ecommDbContext.Orders.Include(o => o.OrderItems).ThenInclude(u => u.Product).Include(u => u.User).ToListAsync();
        //    //var email = await _ecommDbContext.Users.FirstOrDefaultAsync(u => u.Equals(userId));
        //    if (userRole != "Admin")
        //    {
        //        orders = orders.Where(u => u.CustomerId == userId).ToList();
        //    }
        //    return orders;
        //}
    }
}
