using e_commerceApp.Application.Dto;
using e_commerceApp.Shared;
using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Services.Interface
{
    public interface ICategoryService
    { 
            Task<ServiceResponse<List<CategoryDto>>> GetAllCategoryAsync();
            Task<ServiceResponse<Category>> GetCategoryByIdAsync(string id);
            Task<ServiceResponse<Category>> AddCategory(CreateCategory createCategory);
            Task<ServiceResponse<Category>> UpdateCategory(string id, UpdateCategory updateCategory);
            Task<ServiceResponse<bool>> DeleteCategoryByIdAsync(string id);
        

    }
}
