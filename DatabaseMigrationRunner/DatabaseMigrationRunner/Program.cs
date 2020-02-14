using System;
using CommandLine;
using DatabaseMigrationRunner.Configurations;
using DatabaseMigrationRunner.Utilities;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DatabaseMigrationRunner
{
  public class Program
  {
    public static void Main(string[] args)
    {
      try
      {
        CommandOptions cmdOptions = new CommandOptions();
        Parser.Default.ParseArguments<CommandOptions>(args).WithParsed(options =>
        {
          InitializeApplication(options);
        });
      }
      catch (Exception ex)
      {
        Console.WriteLine($"{DateTime.UtcNow} - [ERR] - Error Occurred in migrations");
        Console.WriteLine(ex?.Message);
        Console.WriteLine(ex?.InnerException);
        Console.WriteLine(ex?.StackTrace);
      }
    }

    public static void InitializeApplication(CommandOptions options)
    {
      if (options.IsValid())
      {
        var appSettings = AppInitializer.BindAndGetAppSettings(options.Environment);

        LoggerUtility.ConfigureSeriLog();

        var serviceProvider = CreateServices(appSettings);

        // Put the database update into a scope to ensure
        // that all resources will be disposed.
        using (var scope = serviceProvider.CreateScope())
        {
          UpdateDatabase(scope.ServiceProvider);
        }
      }
    }

    /// <summary>
    /// Configure the dependency injection services
    /// </summary>
    private static IServiceProvider CreateServices(AppSettings appSettings)
    {
      return new ServiceCollection()
          // Add common FluentMigrator services
          .AddFluentMigratorCore()
          .ConfigureRunner(rb => rb
              // Add Sql Server support to FluentMigrator
              .AddSqlServer()
              // Set the connection string
              .WithGlobalConnectionString(appSettings.ConnectionStrings.AppDbConnectionString)
              // Define the assembly containing the migrations
              .ScanIn(typeof(Program).Assembly).For.Migrations())
          // Enable logging to console in the FluentMigrator way
          .AddLogging(lb => lb.AddSerilog())
          // Build the service provider
          .BuildServiceProvider(false);
    }

    /// <summary>
    /// Update the database
    /// </summary>
    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
      // Instantiate the runner
      var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

      // Execute the migrations
      runner.MigrateUp();
    }
  }
}