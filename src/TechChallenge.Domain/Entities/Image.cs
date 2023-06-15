namespace TechChallenge.Domain.Entities;

public class Image
{
    public ImageId? Id { get; set; }

    public required string Url { get; init; }

    public required string Name { get; init; }

    public required ProductId ProductId { get; init; }

    public static class Factory 
    {
        public static Image New(string url, string name, ProductId productId)
            => new() { Id = new ImageId(), Url = url, Name = name, ProductId = productId };
    }
}
