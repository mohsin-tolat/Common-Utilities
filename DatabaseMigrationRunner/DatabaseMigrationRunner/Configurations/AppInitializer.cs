using System.IO;
using Microsoft.Extensions.Configuration;

namespace DatabaseMigrationRunner.Configurations
{
  public static class AppInitializer
  {
    public static AppSettings BindAndGetAppSettings()
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

      IConfigurationRoot configuration = builder.Build();

      AppSettings appSettings = new AppSettings();

      configuration.Bind(appSettings);

      return appSettings;
    }
  }
}