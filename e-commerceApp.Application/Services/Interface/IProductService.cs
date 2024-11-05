using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> AddProduct(Product product);
        Task DeleteProductByIdAsync(int id);
        Task<Product> UpdateProduct(int id, Product product);
    }
}
