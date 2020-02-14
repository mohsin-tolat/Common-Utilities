using CommandLine;

namespace DatabaseMigrationRunner.Configurations
{
  public class CommandOptions
  {
    [Option('e', "Environment", Required = true, HelpText = "Set The Environment.")]
    public string Environment { get; set; }

    public bool IsValid()
    {
      // Place Validation Check here
      return true;
    }
  }
}