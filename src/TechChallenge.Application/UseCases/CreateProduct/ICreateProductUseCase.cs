using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.UseCases.CreateProduct;

public interface ICreateProductUseCase
{
    Task<Product> ExecuteAsync(CreateProductUseCaseInput input, CancellationToken cancellation = default);
}