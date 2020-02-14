namespace DatabaseMigrationRunner.TagsAttributes
{
  public class DevelopmentEnvironmentTagAttribute : AllEnvironmentTagAttribute
  {
    public DevelopmentEnvironmentTagAttribute() : base(GetTagNames())
    {
    }

    private static string[] GetTagNames()
    {
      return new string[] { "Development" };
    }
  }
}