using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.UseCases.CreateImage;
public class CreateImageUseCaseInput
{
    public required Stream Stream { get; init; }

    public required Guid ProductId { get; init; }

    public required string Extension { get; init; }

    public string Filename
        => $"{Guid.NewGuid()}_{ProductId}.{Extension}";
}
