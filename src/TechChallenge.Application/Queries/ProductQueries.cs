using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application.Queries;
public class ProductQueries : IProductQueries
{
    private readonly IProductRepository _productRepository;
    private readonly IImageRepository _imageRepository;

    public ProductQueries(IProductRepository productRepository, IImageRepository imageRepository)
    {
        _productRepository = productRepository;
        _imageRepository = imageRepository;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);

        if (products is null) return default;

        foreach (var product in products)
        {
            product.Images = await _imageRepository.GetImagesByProductIdAsync(product.Id, cancellationToken);
        }

        return products;
    }

    public async Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetByIdAsync(productId, cancellationToken);

        if (product is null) return default;

        product.Images = await _imageRepository.GetImagesByProductIdAsync(productId, cancellationToken);

        return product;
    }
}
