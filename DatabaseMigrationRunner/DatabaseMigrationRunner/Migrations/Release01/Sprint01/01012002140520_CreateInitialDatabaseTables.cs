using DatabaseMigrationRunner.TagsAttributes;
using FluentMigrator;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrationRunner.Migrations.Release01.Sprint01
{
  [CustomDatabaseMigrationRunner(01, 01, 20, 02, 14, 05, 04, "Initial Database Table Scripts", "Mohsin")]
  public class _01012002140520_CreateInitialDatabaseTables : AutoReversingMigration
  {
    private readonly ILogger<_01012002140520_CreateInitialDatabaseTables> logger;

    public _01012002140520_CreateInitialDatabaseTables(ILogger<_01012002140520_CreateInitialDatabaseTables> logger)
    {
      this.logger = logger;
    }

    public override void Up()
    {
      this.logger.LogDebug("Up Method From _01012002140520_CreateInitialDatabaseTables Started");

      // Place Your Initial Setup here.

      this.logger.LogDebug("Up Method From _01012002140520_CreateInitialDatabaseTables End");
    }
  }
}