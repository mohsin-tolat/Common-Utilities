
using EncryptionUtility.API.Interfaces;
using EncryptionUtility.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EncryptionUtility.API.Configuration
{
    public static class DependencyConfiguration
    {
	// Comment For test
        public static void ConfigureDependency(this IServiceCollection services, IConfiguration databaseConfiguration)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<IEncryptionService, AesEncryptionService>();
        }
    }
}