using Azure.Storage.Blobs;
using Lama.Core.Infrastructure.Contracts;
using Lama.Core.Infrastructure.Models;
using Lama.Core.Infrastructure.Models.ICloudStorageService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Lama.Core.Services.AzureStorageService;
public class AzureStorageService : ICloudStorageService
{
    private readonly ILogger<AzureStorageService> _logger;
    private readonly BlobServiceClient _blobServiceClient;

    public AzureStorageService(IConfiguration configuration, ILogger<AzureStorageService> logger)
    {
        _logger = logger;
        _blobServiceClient = new BlobServiceClient(configuration["AzureStorageConnectionString"]);
    }

    public ServiceResponse<UploadedFile> GetFile(string refId)
    {
        throw new NotImplementedException();
    }

    public ServiceResponse<UploadedFile> GetFileByFilename(string filename)
    {
        throw new NotImplementedException();
    }

    public ServiceResponse<UploadedFile> GetFileByRefId(string refId)
    {
        throw new NotImplementedException();
    }

    public ServiceResponse<UploadedFile> UploadFile(string baseUrl, string container, string filename, Stream stream)
    {
        try
        {
            var uniqueFilename = Guid.NewGuid() + Path.GetExtension(filename).ToLower();
            var blobContainer = _blobServiceClient.GetBlobContainerClient(container);
            var blockBlob = blobContainer.UploadBlob(uniqueFilename, stream);

            return new ServiceResponse<UploadedFile>(0, "OK", new UploadedFile
            {
                PublicUrl = $"{baseUrl}/{container}/{uniqueFilename}",
                Filename = uniqueFilename,
                OriginFilename = filename,
                RefId = blockBlob.Value.VersionId
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ServiceResponse<UploadedFile>(-1, ex.Message, null);
        }
    }
}
