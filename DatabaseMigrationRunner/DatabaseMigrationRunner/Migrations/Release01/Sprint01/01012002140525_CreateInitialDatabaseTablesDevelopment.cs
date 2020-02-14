using DatabaseMigrationRunner.TagsAttributes;
using FluentMigrator;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrationRunner.Migrations.Release01.Sprint01
{
  [DevelopmentEnvironmentTag]
  [CustomDatabaseMigrationRunner(01, 01, 20, 02, 14, 05, 25, "Initial Database Table Scripts DevelopmentEnvironmentTag", "Mohsin")]
  public class _01012002140525_CreateInitialDatabaseTablesDevelopment : AutoReversingMigration
  {
    private readonly ILogger<_01012002140525_CreateInitialDatabaseTablesDevelopment> logger;

    public _01012002140525_CreateInitialDatabaseTablesDevelopment(ILogger<_01012002140525_CreateInitialDatabaseTablesDevelopment> logger)
    {
      this.logger = logger;
    }

    public override void Up()
    {
      this.logger.LogDebug("Up Method From _01012002140525_CreateInitialDatabaseTablesDevelopment Started");

      // Place Your Initial Setup here.

      this.logger.LogDebug("Up Method From _01012002140525_CreateInitialDatabaseTablesDevelopment End");
    }
  }
}