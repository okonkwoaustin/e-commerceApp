using e_commerceApp.Shared.Models;

namespace e_commerceApp.Shared.Persistence.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
    }
}
