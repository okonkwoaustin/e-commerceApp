using AutoMapper;
using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerceApp.Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly EcommDbContext _ecommDbContext;
        private readonly IMapper _mapper;

        public CategoryService(EcommDbContext ecommDbContext, IMapper mapper)
        {
            _ecommDbContext = ecommDbContext;
            _mapper = mapper;
        }
        public async Task<List<Category>> GetAllCategoryAsync()
        {
            var categoryDetail = await _ecommDbContext.Categorys
                .ToListAsync();
            return categoryDetail;
        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var categoryDetails = await _ecommDbContext.Categorys
                .FirstOrDefaultAsync(u => u.Id == id);
            if (categoryDetails == null)
            {
                return null;
            }
            return categoryDetails;
        }
        public async Task DeleteCategoryByIdAsync(int id)
        {
            var categoryDetail = await _ecommDbContext.Categorys
               .FirstOrDefaultAsync(u => u.Id == id);
            if (categoryDetail != null)
            {
                _ecommDbContext.Categorys.Remove(categoryDetail);
                _ecommDbContext.SaveChanges();
            }
        }

        public async Task<Category> AddCategory(CreateCategory createCategory)
        {
            var category = _mapper.Map<Category>(createCategory);   
            var addCategory = await _ecommDbContext.Categorys.AddAsync(category);
            await _ecommDbContext.SaveChangesAsync();
            if (addCategory == null)
            {
                return null;
            }
            return addCategory.Entity;
        }


        public async Task<Category> UpdateCategory(int id, UpdateCategory updateCategory)
        {
            var category = _mapper.Map<Category>(updateCategory);
            var getCategory = await _ecommDbContext.Categorys.FirstOrDefaultAsync(u => u.Id == id);
            if (getCategory == null)
            {
                return null;
            }
            _ecommDbContext.Categorys.Update(category);
            _ecommDbContext.SaveChanges();
            return category;
        }
    }
}
