using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Queries;
public interface IImageQueries
{
    Task<IEnumerable<Image>> GetImagesByProductIdAsync(Guid productId, CancellationToken cancellationToken);
}
