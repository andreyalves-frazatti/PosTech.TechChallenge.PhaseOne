using Azure.Storage.Blobs;
using TechChallenge.Application.Services;

namespace TechChallenge.Infrastructure;
public class AzureBlobStorageService : IBlobStorageService
{
    private readonly string _blobStorageConnectionString;
    private readonly string _blobContainerName;

    public AzureBlobStorageService(string blobStorageConnectionString)
    {
        _blobStorageConnectionString = blobStorageConnectionString;
        _blobContainerName = "uploads";
    }

    async Task<Uri> IBlobStorageService.UploadAsync(string filename, Stream stream, CancellationToken cancellationToken)
    {
        var blobServiceClient = new BlobServiceClient(_blobStorageConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_blobContainerName);

        var blobClient = containerClient.GetBlobClient(filename);
        await blobClient.UploadAsync(stream, cancellationToken);

        return blobClient.Uri;
    }
}
