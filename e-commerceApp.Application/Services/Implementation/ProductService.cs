using AutoMapper;
using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared;
using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerceApp.Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly EcommDbContext _ecommDbContext;
        private readonly IMapper _mapper;

        public ProductService(EcommDbContext ecommDbContext, IMapper mapper)
        {
            _ecommDbContext = ecommDbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Product>> GetProductByIdAsync(string id)
        {
            var productDetails = await _ecommDbContext.Products
                .Include(u => u.Reviews)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (productDetails == null)
            {
                return new ServiceResponse<Product>(null!, success: false, message: "Product not found.");
            }

            return new ServiceResponse<Product>(productDetails, success: true, message: "Product retrieved successfully.");
        }
        public async Task<ServiceResponse<List<Product>>> GetAllProductAsync()
        {
            var productDetail = await _ecommDbContext.Products
                .Include(u => u.Reviews)
                .ToListAsync();

            return new ServiceResponse<List<Product>>(productDetail, success: true, message: "Products retrieved successfully.");
        }
        public async Task<ServiceResponse<PagedResult<Product>>> GetPagedProductsAsync(int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;

            var products = await _ecommDbContext.Products
                .Include(u => u.Reviews)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            var totalCount = await _ecommDbContext.Products.CountAsync();

            var result = new PagedResult<Product>
            {
                TotalCount = totalCount,
                Items = products
            };

            return new ServiceResponse<PagedResult<Product>>(result, success: true, message: "Paged products retrieved successfully.");
        }
        public async Task<ServiceResponse<bool>> DeleteProductByIdAsync(string id)
        {
            var productDetail = await _ecommDbContext.Products
                .Include(u => u.Reviews)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (productDetail == null)
            {
                return new ServiceResponse<bool>(false, success: false, message: "Product not found.");
            }

            _ecommDbContext.Products.Remove(productDetail);
            await _ecommDbContext.SaveChangesAsync();

            return new ServiceResponse<bool>(true, success: true, message: "Product deleted successfully.");
        }

        public async Task<ServiceResponse<Product>> AddProduct(CreateProduct createProduct)
        {
            var product = _mapper.Map<Product>(createProduct);
            await _ecommDbContext.Products.AddAsync(product);
            await _ecommDbContext.SaveChangesAsync();

            return new ServiceResponse<Product>(product, success: true, message: "Product added successfully.");
        }

        public async Task<ServiceResponse<Product>> UpdateProduct(string id, UpdateProduct updateProduct)
        {
            var product = await _ecommDbContext.Products.FirstOrDefaultAsync(u => u.Id == id);

            if (product == null)
            {
                return new ServiceResponse<Product>(null!, success: false, message: "Product not found.");
            }
            _mapper.Map(updateProduct, product);

            _ecommDbContext.Products.Update(product);
            await _ecommDbContext.SaveChangesAsync();

            return new ServiceResponse<Product>(product, success: true, message: "Product updated successfully.");
        }

    }
}
