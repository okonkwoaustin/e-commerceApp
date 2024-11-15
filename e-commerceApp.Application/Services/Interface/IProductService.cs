using e_commerceApp.Application.Dto;
using e_commerceApp.Shared;
using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IProductService
    {
        Task<ServiceResponse<Product>> GetProductByIdAsync(string id);
        Task<ServiceResponse<List<Product>>> GetAllProductAsync();

        Task<ServiceResponse<PagedResult<Product>>> GetPagedProductsAsync(int pageNumber, int pageSize);
        Task<ServiceResponse<bool>> DeleteProductByIdAsync(string id);
        Task<ServiceResponse<Product>> AddProduct(CreateProduct createProduct);
        Task<ServiceResponse<Product>> UpdateProduct(string id, UpdateProduct updateProduct);
    }
}
