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

    public async Task DeleteAsync(Guid productId, CancellationToken cancellationToken)
    {
        var query = "DELETE FROM[dbo].[PRODUCTS] WHERE Id = @productId";

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        var @params = new { productId };

        await connection.ExecuteAsync(query, @params);
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM [dbo].[PRODUCTS]";

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        return connection.Query<Product>(query).ToList();
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

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        var query = "UPDATE [dbo].[PRODUCTS] SET Name = @Name, Description = @Description, Price = @Price WHERE Id = @Id";

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync(query, product);
    }
}
