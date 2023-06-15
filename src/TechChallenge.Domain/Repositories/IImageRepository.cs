using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Repositories;

public interface IImageRepository
{
    Task InsertOneAsync(Image image, CancellationToken cancellationToken);

    Task<IEnumerable<Image>> GetImagesByProductIdAsync(ProductId productId, CancellationToken cancellationToken);
}