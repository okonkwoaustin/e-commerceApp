using e_commerceApp.Application.Dto;
using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> AddProduct(CreateProduct product);
        Task DeleteProductByIdAsync(int id);
        Task<Product> UpdateProduct(int id, UpdateProduct product);
        Task<PagedResult<Product>> GetPagedProductsAsync(int pageNumber, int pageSize);
    }
}
