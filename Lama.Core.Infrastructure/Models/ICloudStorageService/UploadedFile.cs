namespace Lama.Core.Infrastructure.Models.ICloudStorageService;

public class UploadedFile
{
    public string RefId { get; set; }
    public string Filename { get; set; }
    public string OriginFilename { get; set; }

    public string PublicUrl { get; set; }
    public string PrivateUrl { get; set; }
}