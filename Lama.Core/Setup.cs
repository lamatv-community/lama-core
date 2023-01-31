using Lama.Core.Infrastructure.Contracts;
using Lama.Core.Services.AzureStorageService;

namespace Lama.Core;

public static class Setup
{
    public static void AddLamaServices(this IServiceCollection services)
    {
        services.AddSingleton<ICloudStorageService, AzureStorageService>();
    }
    
    public static void AddLamaFacades(this IServiceCollection services)
    {
    }
}