using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application;
using TechChallenge.Application.UseCases.CreateProduct;
using TechChallenge.Application.Queries;
using TechChallenge.Web.Models;

namespace TechChallenge.Web.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductController : ControllerBase
{
    private readonly IProductQueries _productQueries;
    private readonly ICreateProductUseCase _createProductUseCase;

    public ProductController(IProductQueries productQueries, ICreateProductUseCase createProductUseCase)
    {
        _productQueries = productQueries;
        _createProductUseCase = createProductUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var product = await _productQueries.GetAllAsync(cancellationToken);

        return product is not null ? Ok(product) : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] Guid productId, CancellationToken cancellationToken)
    {
        var product = await _productQueries.GetByIdAsync(productId, cancellationToken);

        return product is not null ? Ok(product) : NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductViewModel viewModel, CancellationToken cancellationToken)
    { 
        CreateProductUseCaseInput input = new()
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            Price = viewModel.Price
        };

        var product = await _createProductUseCase.ExecuteAsync(input, cancellationToken);

        return Ok(product);
    }
}
