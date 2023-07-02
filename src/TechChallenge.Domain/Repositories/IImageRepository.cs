using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Repositories;

public interface IImageRepository
{
    Task<Image> GetImageByIdAsync(Guid imageId, CancellationToken cancellationToken);

    Task DeleteAsync(Guid imageId, CancellationToken cancellationToken);

    Task InsertOneAsync(Image image, CancellationToken cancellationToken);

    Task<IEnumerable<Image>> GetImagesByProductIdAsync(Guid productId, CancellationToken cancellationToken);
}