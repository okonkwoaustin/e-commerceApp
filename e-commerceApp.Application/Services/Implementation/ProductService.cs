using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerceApp.Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly EcommDbContext _ecommDbContext;

        public ProductService(EcommDbContext ecommDbContext)
        {
            _ecommDbContext = ecommDbContext;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _ecommDbContext.Products
                .Include(u => u.Reviews)
                .FirstOrDefaultAsync(u => u.Id == id);
            if(productDetails == null)
            {
                return null;
            }
            return productDetails;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            var productDetail = await _ecommDbContext.Products
                .Include(u => u.Reviews)
                .ToListAsync();
            return productDetail;
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            var productDetail = await _ecommDbContext.Products
               .Include(u => u.Reviews)
               .FirstOrDefaultAsync(u => u.Id == id);
            if (productDetail != null)
            {
                _ecommDbContext.Products.Remove(productDetail);
                _ecommDbContext.SaveChanges();
            }
        }

        public async Task<Product> AddProduct(Product product)
        {
            var addProduct = await _ecommDbContext.Products.AddAsync(product);
            await _ecommDbContext.SaveChangesAsync();
            if (addProduct == null)
            {
                return null;
            }
            return addProduct.Entity;
        }


        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var getProduct = await _ecommDbContext.Products.FirstOrDefaultAsync(u => u.Id == id);
            if (getProduct == null)
            {
                return null;
            }
            _ecommDbContext.Products.Update(product);
            return product;
        }

    }
}
