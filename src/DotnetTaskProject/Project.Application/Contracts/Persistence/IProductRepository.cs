using Project.Domain.Entities;

namespace Project.Application.Contracts.Persistence
{
    public interface IProductRepository
	{
		Task<IReadOnlyList<Product>> GetProductsAsync();
		Task<IReadOnlyList<Product>> GetProductsByUserIdAsync(Guid userId);
		Task<Product?> GetProductAsync(string manufactureEmail, DateTime productDate);
		Task DeleteProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task CreateProductAsync(Product product);
		Task<bool> ProductExistAsync(string manufactureEmail, DateTime productDate);
		Task<bool> ProductExistAsync(int productId);
		Task<Product?> GetProductByIdAsync(int productId);
	}
}