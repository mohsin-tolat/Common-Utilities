using DatabaseMigrationRunner.TagsAttributes;
using FluentMigrator;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrationRunner.Migrations.Release01.Sprint01
{
  [TestingEnvironmentTag]
  [CustomDatabaseMigrationRunner(01, 01, 20, 02, 14, 05, 30, "Initial Database Table Scripts TestingEnvironmentTag", "Mohsin")]
  public class _01012002140530_CreateInitialDatabaseTablesTesting : AutoReversingMigration
  {
    private readonly ILogger<_01012002140530_CreateInitialDatabaseTablesTesting> logger;

    public _01012002140530_CreateInitialDatabaseTablesTesting(ILogger<_01012002140530_CreateInitialDatabaseTablesTesting> logger)
    {
      this.logger = logger;
    }

    public override void Up()
    {
      this.logger.LogDebug("Up Method From _01012002140530_CreateInitialDatabaseTablesTesting Started");

      // Place Your Initial Setup here.

      this.logger.LogDebug("Up Method From _01012002140530_CreateInitialDatabaseTablesTesting End");
    }
  }
}