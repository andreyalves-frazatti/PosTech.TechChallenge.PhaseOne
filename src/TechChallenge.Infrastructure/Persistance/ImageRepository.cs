﻿using Dapper;
using Microsoft.Data.SqlClient;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Infrastructure.Persistence;
public class ImageRepository : IImageRepository
{
    private readonly string _connectionString;

    public ImageRepository(SqlConnectionString sqlConnectionString)
    {
        _connectionString = sqlConnectionString.ConnectionString;
    }

    public async Task<IEnumerable<Image>> GetImagesByProductIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM [dbo].[IMAGES] WITH(NOLOCK) WHERE ProductId = @productId";

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        var @params = new { productId };

        return await connection.QueryAsync<Image>(query, @params);
    }

    public async Task InsertOneAsync(Image image, CancellationToken cancellationToken)
    {
        var query = "INSERT INTO [dbo].[IMAGES] VALUES (@Id, @Name, @Url, @ProductId)";

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync(query, image);
    }
}
