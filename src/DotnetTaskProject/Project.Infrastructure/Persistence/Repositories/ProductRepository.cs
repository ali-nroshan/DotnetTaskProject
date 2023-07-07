using Microsoft.EntityFrameworkCore;
using Project.Application.Contracts.Persistence;
using Project.Domain.Entities;
using Project.Infrastructure.Persistence.Context;

namespace Project.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectDbContext _context;

        public ProductRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductAsync(string manufactureEmail, DateTime productDate)
        {
            return await _context.Products.SingleOrDefaultAsync(q => q.ManufactureEmail == manufactureEmail
            && q.ProductDate == productDate);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsByUserIdAsync(Guid userId)
        {
            return await _context.Products.Where(q => q.UserId == userId).ToListAsync();
        }

        public async Task<bool> ProductExistAsync(string manufactureEmail, DateTime productDate)
        {
            var product = await GetProductAsync(manufactureEmail, productDate);
            return product != null;
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ProductExistAsync(int productId)
        {
            return await _context.Products.AnyAsync(q => q.ProductId == productId);
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

	}
}
