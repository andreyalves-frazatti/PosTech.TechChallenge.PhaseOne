using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application.UseCases.CreateProduct;

public class CreateProductUseCase : ICreateProductUseCase
{
    private readonly IProductRepository _productRepository;

    public CreateProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> ExecuteAsync(CreateProductUseCaseInput input, CancellationToken cancellationToken)
    {
        Product product = new()
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            Description = input.Description,
            Price = input.Price
        };

        await _productRepository.InsertOneAsync(product, cancellationToken);

        return product;
    }
}