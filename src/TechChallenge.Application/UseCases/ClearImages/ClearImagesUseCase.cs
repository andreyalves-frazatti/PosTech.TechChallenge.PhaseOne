using TechChallenge.Application.UseCases.DeleteImage;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application.UseCases.ClearImages
{
    public class ClearImagesUseCase : IClearImagesUseCase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IDeleteImageUseCase _deleteImageUseCase;

        public ClearImagesUseCase(
            IImageRepository imageRepository,
            IDeleteImageUseCase deleteImageUseCase)
        {
            _imageRepository = imageRepository;
            _deleteImageUseCase = deleteImageUseCase;
        }

        public async Task ExecuteAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            var images = await _imageRepository.GetImagesByProductIdAsync(productId, cancellationToken);

            foreach (var image in images)
            {
                await _deleteImageUseCase.ExecuteAsync(image.Id, cancellationToken);
            }
        }
    }
}
