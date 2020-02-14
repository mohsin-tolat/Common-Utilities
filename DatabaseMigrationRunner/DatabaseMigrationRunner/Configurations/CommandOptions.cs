using CommandLine;
using DatabaseMigrationRunner.Exceptions;

namespace DatabaseMigrationRunner.Configurations
{
  public class CommandOptions
  {
    [Option('e', "Environment", Required = true, HelpText = "Set The Environment.")]
    public string Environment { get; set; }

    [Option('v', "Version", Required = false, HelpText = "Set The Version Number till which you want to up the database.")]
    public long? Version { get; set; }

    [Option('t', "Type", Required = true, HelpText = "Set The Migration Run Type to Up or Down, Up if you want to update the change or Down if you want to revert the changes.")]
    public MigrationRunType MigrationRunType { get; set; }

    public bool IsValid()
    {
      // Place Validation Check here
      if (this.MigrationRunType == MigrationRunType.Down && !this.Version.HasValue)
      {
        throw new CommandInvalidException($"Please pass version number to migrate down.");
      }

      return true;
    }
  }

  public enum MigrationRunType
  {
    Up = 1,
    Down = 2
  }
}