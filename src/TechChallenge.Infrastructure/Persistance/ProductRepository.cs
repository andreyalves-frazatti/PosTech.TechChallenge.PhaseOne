using Dapper;
using Microsoft.Data.SqlClient;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Infrastructure.Persistence;
public class ProductRepository : IProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(SqlConnectionString sqlConnectionString)
    {
        _connectionString = sqlConnectionString.ConnectionString;
    }

    public async Task<Product?> GetByIdAsync(ProductId productId, CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM [dbo].[PRODUCT] WITH(NOLOCK) WHERE ProductId = @productId";

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        var @params = new { ProductId = productId.Id };

        return connection.QueryFirstOrDefault<Product>(query, @params);
    }

    public async Task InsertOneAsync(Product product, CancellationToken cancellationToken)
    {
        var query = "INSERT INTO [dbo].[PRODUCT] VALUES (@ProductId, @Name, @Description, @Price)";

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        var @params = new
        {
            ProductId = product.Id.Id,
            product.Name,
            product.Description,
            product.Price
        };

        await connection.ExecuteAsync(query, @params);
    }
}
