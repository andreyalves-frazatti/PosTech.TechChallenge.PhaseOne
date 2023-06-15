
using TechChallenge.Application.UseCases.CreateImage;
using TechChallenge.Domain.Repositories;
using TechChallenge.Application.Services;
using TechChallenge.Infrastructure.Persistence;
using TechChallenge.Infrastructure;
using TechChallenge.Application;
using TechChallenge.Application.UseCases.CreateProduct;

namespace TechChallenge.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var azureBlobStorageConnectionString = builder.Configuration.GetConnectionString("AzureBlobStorage");        
        builder.Services.AddScoped<IBlobStorageService>(_ => new AzureBlobStorageService(azureBlobStorageConnectionString!));

        var sqlConnectionString = builder.Configuration.GetConnectionString("AzureSqlServer");
        builder.Services.AddScoped(_ => new SqlConnectionString(sqlConnectionString!));

        builder.Services.AddScoped<IImageRepository, ImageRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddScoped<IProductQueries, ProductQueries>();
        builder.Services.AddScoped<ICreateImageUseCase, CreateImageUseCase>();
        builder.Services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();        

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
