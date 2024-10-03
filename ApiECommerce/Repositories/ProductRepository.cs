using ApiECommerce.Context;
using ApiECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiECommerce.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetBestSellerProductsAsync()
        {
            return await _context.Products.Where(p => p.BestSeller).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetPopularProductsAsync()
        {
            return await _context.Products.Where(p => p.Popular).ToListAsync();
        }

        public async Task<Product> GetProductDetailsAsync(int id)
        {
            var productDetail = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            //if (productDetail is null) throw new InvalidOperationException("O produto procurado não existe");

            return productDetail!;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }
    }
}
