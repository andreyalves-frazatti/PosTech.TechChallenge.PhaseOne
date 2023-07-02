using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Repositories;

public interface IProductRepository
{
    Task InsertOneAsync(Product product, CancellationToken cancellationToken);

    Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken);

    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);

    Task DeleteAsync(Guid productId, CancellationToken cancellationToken);

    Task UpdateAsync(Product product, CancellationToken cancellationToken);
}