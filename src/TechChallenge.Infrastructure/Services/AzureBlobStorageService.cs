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

    public async Task<Uri> UploadAsync(string filename, Stream stream, CancellationToken cancellationToken)
    {
        var blobServiceClient = new BlobServiceClient(_blobStorageConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_blobContainerName);

        var blobClient = containerClient.GetBlobClient(filename);
        await blobClient.UploadAsync(stream, cancellationToken);

        return blobClient.Uri;
    }

    public async Task DeleteAsync(string blobUri, CancellationToken cancellationToken)
    {
        var blobServiceClient = new BlobServiceClient(_blobStorageConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_blobContainerName);

        var blobUriBuilder = new BlobUriBuilder(new Uri(blobUri));
        await containerClient.DeleteBlobAsync(blobUriBuilder.BlobName, cancellationToken: cancellationToken);
    }
}
