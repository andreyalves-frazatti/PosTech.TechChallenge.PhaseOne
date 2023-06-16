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

    public async Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM [dbo].[PRODUCTS] WITH(NOLOCK) WHERE Id = @productId";

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        var @params = new { productId };

        return connection.QueryFirstOrDefault<Product>(query, @params);
    }

    public async Task InsertOneAsync(Product product, CancellationToken cancellationToken)
    {
        var query = "INSERT INTO [dbo].[PRODUCTS] VALUES (@Id, @Name, @Description, @Price)";

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync(query, product);
    }
}
