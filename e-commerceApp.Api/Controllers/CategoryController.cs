using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("getAllProduct")]
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
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _categoryService.GetCategoryByIdAsync(id));
        }
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> Edit(UpdateCategory category, int id)
        {
            return Ok(await _categoryService.UpdateCategory(id, category));
        }
        [HttpPost]
        public IActionResult DeleteActor(int id)
        {
            return Ok(_categoryService.DeleteCategoryByIdAsync(id));
        }
    }
}
