using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using e_commerceApp.Shared.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace e_commerceApp.Shared.Persistence.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommDbContext _ecommDbContext;

        public ProductRepository(EcommDbContext ecommDbContext) 
        {
            _ecommDbContext = ecommDbContext;
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var productDetails = await _ecommDbContext.Products
                //.Include(u => u.Review)
                .FirstOrDefaultAsync(u => u.Id == id);
            return productDetails;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            var productDetail = await _ecommDbContext.Products
                //.Include(u => u.Review)
                .ToListAsync();
            return productDetail;
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            var productDetail = await _ecommDbContext.Products
               //.Include(u => u.Review)
               .FirstOrDefaultAsync(u => u.Id == id);
            _ecommDbContext.Products.Remove(productDetail);
            
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
