using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application.Queries;
public class ImageQueries : IImageQueries
{
    private readonly IImageRepository _imageRepository;

    public ImageQueries(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<IEnumerable<Image>> GetImagesByProductIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        return await _imageRepository.GetImagesByProductIdAsync(productId, cancellationToken);
    }
}
