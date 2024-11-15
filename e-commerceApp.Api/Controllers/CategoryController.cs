using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace e_commerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("getAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var data = await _categoryService.GetAllCategoryAsync();
            return Ok(data);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateCategory category)
        {
            return Ok(_categoryService.AddCategory(category));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            return Ok(await _categoryService.GetCategoryByIdAsync(id));
        }
        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> Edit(UpdateCategory category, string id)
        {
            return Ok(await _categoryService.UpdateCategory(id, category));
        }
        [HttpPost]
        public IActionResult DeleteCategory(string id)
        {
            return Ok(_categoryService.DeleteCategoryByIdAsync(id));
        }
    }
}
