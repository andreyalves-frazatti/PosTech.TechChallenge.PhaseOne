using TechChallenge.Application.Services;
using TechChallenge.Application.UseCases.DeleteImage;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application.UseCases.DeleteProduct
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _productRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
