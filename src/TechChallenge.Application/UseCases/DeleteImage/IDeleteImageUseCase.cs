namespace TechChallenge.Application.UseCases.DeleteImage
{
    public interface IDeleteImageUseCase
    {
        Task ExecuteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
