using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var data = await _productService.GetAllProductAsync();
            return Ok(data);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateProduct product)
        {
            return Ok(_productService.AddProduct(product));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
           return Ok(await _productService.GetProductByIdAsync(id));
        }
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> Edit(UpdateProduct product, int id)
        {
                return Ok(await _productService.UpdateProduct(id, product));
        }
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            return Ok(_productService.DeleteProductByIdAsync(id));
        }

        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<Product>>> GetPagedProducts(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetPagedProductsAsync(pageNumber, pageSize);
            return Ok(result);
        }
    }
}
