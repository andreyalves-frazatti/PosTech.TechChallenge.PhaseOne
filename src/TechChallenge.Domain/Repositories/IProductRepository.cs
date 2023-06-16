using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Repositories;

public interface IProductRepository
{
    Task InsertOneAsync(Product product, CancellationToken cancellationToken);

    Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken);
}