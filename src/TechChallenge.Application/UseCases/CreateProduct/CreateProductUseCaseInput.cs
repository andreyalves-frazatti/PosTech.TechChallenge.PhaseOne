namespace TechChallenge.Application;
public class CreateProductUseCaseInput
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
}
