namespace TechChallenge.Application.UseCases.ClearImages
{
    public interface IClearImagesUseCase
    {
        Task ExecuteAsync(Guid productId, CancellationToken cancellationToken = default);
    }
}
