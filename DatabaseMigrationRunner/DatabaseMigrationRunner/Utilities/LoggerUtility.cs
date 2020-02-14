using Serilog;

namespace DatabaseMigrationRunner.Utilities
{
  public static class LoggerUtility
  {
    public static void ConfigureSeriLog()
    {
      Log.Logger = new LoggerConfiguration()
                      .MinimumLevel.Debug()
                      .WriteTo.Console()
                      .WriteTo.RollingFile("Logs\\Logs-{Date}.log")
                      .CreateLogger();
    }
  }
}