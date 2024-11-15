using AutoMapper;
using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared;
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
        public async Task<ServiceResponse<List<CategoryDto>>> GetAllCategoryAsync()
        {
            var categoryDetail = await _ecommDbContext.Categorys
                .Include(u => u.Products)
                .ToListAsync();

            if (!categoryDetail.Any())
            {
                return new ServiceResponse<List<CategoryDto>>(null, success: false, Initials.NotFound);
            }
            var categoryDtos = categoryDetail.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ProductIds = category.Products!.Select(p => p.Id).ToList()
            }).ToList();

            return new ServiceResponse<List<CategoryDto>>(categoryDtos, success: true, message: "Categories retrieved successfully.");
        }

        public async Task<ServiceResponse<Category>> GetCategoryByIdAsync(string id)
        {
            var categoryDetails = await _ecommDbContext.Categorys
                .FirstOrDefaultAsync(u => u.Id == id);
            if (categoryDetails == null)
            {
                return new ServiceResponse<Category>(null!, success: false, message: "Category not found.");
            }
            return new ServiceResponse<Category>(categoryDetails, success: true, message: "Category retrieved successfully.");
        }

        public async Task<ServiceResponse<bool>> DeleteCategoryByIdAsync(string id)
        {
            var categoryDetail = await _ecommDbContext.Categorys.Include(u => u.Products)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (categoryDetail == null)
            {
                return new ServiceResponse<bool>(false, success: false, message: "Category not found.");
            }
            _ecommDbContext.Categorys.Remove(categoryDetail);
            await _ecommDbContext.SaveChangesAsync();
            return new ServiceResponse<bool>(true, success: true, message: "Category deleted successfully.");
        }

        public async Task<ServiceResponse<Category>> AddCategory(CreateCategory createCategory)
        {
            var category = _mapper.Map<Category>(createCategory);

            await _ecommDbContext.Categorys.AddAsync(category);
            await _ecommDbContext.SaveChangesAsync();
            return new ServiceResponse<Category>(category, success: true, message: "Category added successfully.");
        }

        public async Task<ServiceResponse<Category>> UpdateCategory(string id, UpdateCategory updateCategory)
        {
            var category = await _ecommDbContext.Categorys.FirstOrDefaultAsync(u => u.Id == id);
            if (category == null)
            {
                return new ServiceResponse<Category>(null, success: false, message: "Category not found.");
            }
            _mapper.Map(updateCategory, category);

            _ecommDbContext.Categorys.Update(category);
            await _ecommDbContext.SaveChangesAsync();

            return new ServiceResponse<Category>(category, success: true, message: "Category updated successfully.");
        }

    }
}
