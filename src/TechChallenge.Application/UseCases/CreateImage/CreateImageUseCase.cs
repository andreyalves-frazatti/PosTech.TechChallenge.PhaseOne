using Microsoft.Extensions.Logging;
using TechChallenge.Application.Services;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application.UseCases.CreateImage;

public class CreateImageUseCase : ICreateImageUseCase
{
    private readonly ILogger<CreateImageUseCase> _logger;
    private readonly IBlobStorageService _blobStorageService;
    private readonly IImageRepository _imageRepository;

    public CreateImageUseCase(ILogger<CreateImageUseCase> logger, IBlobStorageService blobStorageService, IImageRepository imageRepository)
    {
        _logger = logger;
        _blobStorageService = blobStorageService;
        _imageRepository = imageRepository;
    }

    public async Task<Image> ExecuteAsync(CreateImageUseCaseInput input, CancellationToken cancellationToken = default)
    {
        try
        {
            var uri = await _blobStorageService.UploadAsync(
            filename: input.Filename,
            stream: input.Stream,
            cancellationToken: cancellationToken);

            var image = Image.Factory.New(
                url: uri.ToString(),
                name: input.Filename,
                productId: input.ProductId);

            await _imageRepository.InsertOneAsync(image, cancellationToken);

            return image;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to create new Image. Input: {@Input}.", input);
            throw;
        }
    }
}
