using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application;
public class ProductQueries : IProductQueries
{
    private readonly IProductRepository _productRepository;
    private readonly IImageRepository _imageRepository;

    public ProductQueries(IProductRepository productRepository, IImageRepository imageRepository)
    {
        _productRepository = productRepository;
        _imageRepository = imageRepository;
    }

    public async Task<Product?> GetByIdAsync(ProductId productId, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetByIdAsync(productId, cancellationToken);

        if (product is null) return default;

        product.Images = await _imageRepository.GetImagesByProductIdAsync(productId, cancellationToken);

        return product;
    }
}
