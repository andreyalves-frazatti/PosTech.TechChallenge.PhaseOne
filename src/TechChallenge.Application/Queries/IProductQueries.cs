using TechChallenge.Domain.Entities;

namespace TechChallenge.Application;
public interface IProductQueries
{
    Task<Product?> GetByIdAsync(ProductId productId, CancellationToken cancellationToken = default);
}
