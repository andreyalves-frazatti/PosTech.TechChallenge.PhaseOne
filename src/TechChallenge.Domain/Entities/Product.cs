namespace TechChallenge.Domain.Entities;

public class Product
{
    public required ProductId Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
    public IEnumerable<Image> Images { get; set; } = Enumerable.Empty<Image>();
}