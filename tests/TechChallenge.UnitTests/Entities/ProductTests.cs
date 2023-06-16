using TechChallenge.Domain.Entities;

namespace TechChallenge.UnitTests.Entities;

public class ProductTests
{
    [Fact]
    public void Should_CreateNewProduct_When_ParamsIsValid()
    {
        /* Arrange */
        var productId = Guid.NewGuid();
        var name = "Processador Intel i9 13900K";
        var description = "Processador Intel";
        var price = 3_900M;

        /* Act */
        Product product = new()
        {
            Id = productId,
            Name = name,
            Description = description,
            Price = price
        };

        /* Assert */
        Assert.NotNull(product);

    }
}