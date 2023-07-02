using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Application.Services;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application.UseCases.DeleteImage
{
    public class DeleteImageUseCase : IDeleteImageUseCase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IBlobStorageService _blobStorageService;

        public DeleteImageUseCase(
            IImageRepository imageRepository,
            IBlobStorageService blobStorageService)
        {
            _imageRepository = imageRepository;
            _blobStorageService = blobStorageService;
        }

        public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var image = await _imageRepository.GetImageByIdAsync(id, cancellationToken);

            await _imageRepository.DeleteAsync(image.Id, cancellationToken);
            await _blobStorageService.DeleteAsync(image.Url, cancellationToken);
        }
    }
}
