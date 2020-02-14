namespace DatabaseMigrationRunner.Configurations
{
  public class AppSettings
  {
    public ConnectionStringsConfiguration ConnectionStrings { get; set; }

    public class ConnectionStringsConfiguration
    {
      public string AppDbConnectionString { get; set; }
    }
  }
}