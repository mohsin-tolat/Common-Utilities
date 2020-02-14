namespace DatabaseMigrationRunner.TagsAttributes
{
  public class TestingEnvironmentTagAttribute : AllEnvironmentTagAttribute
  {
    public TestingEnvironmentTagAttribute() : base(GetTagNames())
    {
    }

    private static string[] GetTagNames()
    {
      return new string[] { "Testing" };
    }
  }
}