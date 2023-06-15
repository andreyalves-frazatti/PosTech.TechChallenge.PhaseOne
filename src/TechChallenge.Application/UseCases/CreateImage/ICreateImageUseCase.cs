using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.UseCases.CreateImage;
public interface ICreateImageUseCase
{
    Task<Image> ExecuteAsync(CreateImageUseCaseInput input, CancellationToken cancellationToken = default);
}
