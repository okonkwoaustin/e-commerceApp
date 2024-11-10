using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerceApp.Application.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly EcommDbContext _context;

        public PaymentService(EcommDbContext context)
        {
            _context = context;
        }

        public Task<bool> CaptureOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateOrder(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
