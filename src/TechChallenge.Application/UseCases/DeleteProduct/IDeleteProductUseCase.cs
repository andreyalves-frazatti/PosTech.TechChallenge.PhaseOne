namespace TechChallenge.Application.UseCases.DeleteProduct
{
    public interface IDeleteProductUseCase
    {
        Task ExecuteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
