using Lama.Core.Infrastructure.Models;
using Lama.Core.Infrastructure.Models.ICloudStorageService;

namespace Lama.Core.Infrastructure.Contracts;

public interface ICloudStorageService
{
    /// <summary>
    /// Provide stream with the file which will be saved on storage
    /// </summary>
    /// <param name="stream">File to be uploaded as Stream</param>
    /// <returns></returns>
    ServiceResponse<UploadedFile> UploadFile(string baseUrl, string container, string filename, Stream stream);
    /// <summary>
    /// Might be useful when proxying files to storage
    /// </summary>
    /// <param name="refId">RefId which was used to store file in the storage provider</param>
    /// <returns></returns>
    ServiceResponse<UploadedFile> GetFileByRefId(string refId);
    /// <summary>
    /// Search for file by filename
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    ServiceResponse<UploadedFile> GetFileByFilename(string filename);

}