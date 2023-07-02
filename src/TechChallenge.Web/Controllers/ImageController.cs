using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.UseCases.CreateImage;
using TechChallenge.Application.Queries;
using TechChallenge.Web.Models;

namespace TechChallenge.Web.Controllers;

[ApiController]
[Route("api/v1/images")]
public class ImageController : ControllerBase
{
    private readonly IImageQueries _imageQueries;
    private readonly ICreateImageUseCase _createImageUseCase;

    public ImageController(ICreateImageUseCase createImageUseCase, IImageQueries imageQueries)
    {
        _createImageUseCase = createImageUseCase;
        _imageQueries = imageQueries;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadAsync([FromForm] CreateImageViewModel viewModel, CancellationToken cancellationToken)
    {
        using var stream = viewModel.File.OpenReadStream();

        CreateImageUseCaseInput input = new()
        {
            Stream = stream,
            Extension = "",
            ProductId = viewModel.ProductId
        };

        var image = await _createImageUseCase.ExecuteAsync(input, cancellationToken);

        return Ok(image);
    }

    [HttpGet("{product-id}")]
    public async Task<IActionResult> UploadAsync([FromRoute(Name = "product-id")] Guid productId, CancellationToken cancellationToken)
    {
        var images = await _imageQueries.GetImagesByProductIdAsync(productId, cancellationToken);

        return images is not null ? Ok(images) : NoContent();
    }
}
