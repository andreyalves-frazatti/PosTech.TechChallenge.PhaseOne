using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.UseCases.CreateImage;

namespace TechChallenge.WebAPI;

[ApiController]
[Route("api/v1/images")]
public class ImageController : ControllerBase
{
    private readonly ICreateImageUseCase _createImageUseCase;

    public ImageController(ICreateImageUseCase createImageUseCase)
    {
        _createImageUseCase = createImageUseCase;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadAsync([FromForm] CreateImageViewModel viewModel, CancellationToken cancellationToken)
    {
        using var stream = viewModel.File.OpenReadStream();

        CreateImageUseCaseInput input = new()
        {
            Stream = stream,
            Extension = "",
            ProductId = new() { Id = viewModel.ProductId }
        };

        var image = await _createImageUseCase.ExecuteAsync(input, cancellationToken);

        return Ok(image);
    }
}
