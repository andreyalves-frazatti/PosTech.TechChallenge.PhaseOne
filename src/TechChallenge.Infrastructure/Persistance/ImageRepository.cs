using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Infrastructure.Persistence;
public class ImageRepository : IImageRepository
{
    public Task<IEnumerable<Image>> GetImagesByProductIdAsync(ProductId productId, CancellationToken cancellationToken)
    {
        return Task.FromResult(Enumerable.Empty<Image>());
    }

    public Task InsertOneAsync(Image image, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
