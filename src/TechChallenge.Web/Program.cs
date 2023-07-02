using TechChallenge.Application.Queries;
using TechChallenge.Application.Services;
using TechChallenge.Application.UseCases.ClearImages;
using TechChallenge.Application.UseCases.CreateImage;
using TechChallenge.Application.UseCases.CreateProduct;
using TechChallenge.Application.UseCases.DeleteImage;
using TechChallenge.Application.UseCases.DeleteProduct;
using TechChallenge.Application.UseCases.EditProduct;
using TechChallenge.Domain.Repositories;
using TechChallenge.Infrastructure;
using TechChallenge.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var azureBlobStorageConnectionString = builder.Configuration.GetConnectionString("AzureBlobStorage");
builder.Services.AddScoped<IBlobStorageService>(_ => new AzureBlobStorageService(azureBlobStorageConnectionString!));

var sqlConnectionString = builder.Configuration.GetConnectionString("AzureSqlServer");
builder.Services.AddScoped(_ => new SqlConnectionString(sqlConnectionString!));

builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductQueries, ProductQueries>();
builder.Services.AddScoped<IImageQueries, ImageQueries>();

builder.Services.AddScoped<ICreateImageUseCase, CreateImageUseCase>();
builder.Services.AddScoped<IDeleteImageUseCase, DeleteImageUseCase>();
builder.Services.AddScoped<IClearImagesUseCase, ClearImagesUseCase>();
builder.Services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
builder.Services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddScoped<IEditProductUseCase, EditProductUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
