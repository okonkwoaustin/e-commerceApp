using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IPaymentService
    {
        Task<string> CreateOrder(decimal amount);
        Task<bool> CaptureOrder(string orderId);
    }
}
