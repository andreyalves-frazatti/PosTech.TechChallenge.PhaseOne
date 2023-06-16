namespace TechChallenge.Domain.Entities;

public class Image
{
    public Guid Id { get; set; }

    public required string Url { get; set; }

    public required string Name { get; set; }

    public required Guid ProductId { get; set; }

    public static class Factory 
    {
        public static Image New(string url, string name, Guid productId)
            => new() { Id = Guid.NewGuid(), Url = url, Name = name, ProductId = productId };
    }
}
