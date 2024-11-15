using e_commerceApp.Application.Services.Implementation;
using e_commerceApp.Application.Services.Interface;

namespace e_commerceApp.Application.Dto
{
    public class ShoppingCartRequest
    {
        public ShoppingCartService ShoppingCartService { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
