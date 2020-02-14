using System;
using CommandLine;
using DatabaseMigrationRunner.Configurations;
using DatabaseMigrationRunner.Utilities;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
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

        var serviceProvider = CreateServices(appSettings, options);

        // Put the database update into a scope to ensure
        // that all resources will be disposed.
        using (var scope = serviceProvider.CreateScope())
        {
          UpdateDatabase(scope.ServiceProvider, appSettings, options);
        }
      }
    }

    /// <summary>
    /// Configure the dependency injection services
    /// </summary>
    private static IServiceProvider CreateServices(AppSettings appSettings, CommandOptions commandOptions)
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
          .Configure<RunnerOptions>(options =>
          {
            options.Tags = new[] { "ALLEnvironment", commandOptions.Environment };
          })
          // Build the service provider
          .BuildServiceProvider(false);
    }

    /// <summary>
    /// Update the database
    /// </summary>
    private static void UpdateDatabase(IServiceProvider serviceProvider, AppSettings appSettings, CommandOptions commandOptions)
    {
      // Instantiate the runner
      var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

      // Execute the migrations

      runner.ListMigrations();

      if (commandOptions.MigrationRunType == MigrationRunType.Down)
      {
        if (runner.HasMigrationsToApplyDown(commandOptions.Version.Value))
        {
          Log.Debug($"Migrations available to Apply Down Version: {commandOptions.Version.Value}");
          runner.MigrateDown(commandOptions.Version.Value);
        }
        else
        {
          Log.Warning($"NO Migrations available to Apply Down to Version: {commandOptions.Version.Value}");
        }
      }
      else
      {
        if (commandOptions.Version.HasValue)
        {
          if (runner.HasMigrationsToApplyUp(commandOptions.Version.Value))
          {
            Log.Debug($"Migrations available to Apply Up to Version: {commandOptions.Version.Value}");
            runner.MigrateUp(commandOptions.Version.Value);
          }
          else
          {
            Log.Warning($"NO Migrations available to Apply Up to Version: {commandOptions.Version.Value}");
          }
        }
        else
        {
          if (runner.HasMigrationsToApplyUp())
          {
            Log.Debug("Migrations available to Apply Up Version: ALL Remaining");
            runner.MigrateUp();
          }
          else
          {
            Log.Warning($"NO Migrations available to Apply Up to Version: ALL Remaining");
          }
        }
      }
    }
  }
}