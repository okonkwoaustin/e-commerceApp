using e_commerceApp.Application.Dto;
using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> AddCategory(CreateCategory category);
        Task DeleteCategoryByIdAsync(int id);
        Task<Category> UpdateCategory(int id, UpdateCategory category);
    }
}
