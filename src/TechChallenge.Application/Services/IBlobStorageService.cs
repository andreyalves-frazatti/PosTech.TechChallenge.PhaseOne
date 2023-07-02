namespace TechChallenge.Application.Services;

public interface IBlobStorageService
{
    Task<Uri> UploadAsync(string filename, Stream stream, CancellationToken cancellationToken);

    Task DeleteAsync(string blobUri, CancellationToken cancellationToken);
}