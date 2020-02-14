using System.Linq;
using FluentMigrator;

namespace DatabaseMigrationRunner.TagsAttributes
{
  public class AllEnvironmentTagAttribute : TagsAttribute
  {
    public AllEnvironmentTagAttribute() : base(TagBehavior.RequireAny, GetTagNames())
    {
    }

    public AllEnvironmentTagAttribute(string[] environments) : base(TagBehavior.RequireAll, GetTagNames(environments))
    {
    }

    private static string[] GetTagNames(string[] environments)
    {
      var allTags = GetTagNames();
      return allTags.Union(environments).ToArray();
    }

    private static string[] GetTagNames()
    {
      return new string[] { "ALLEnvironment" };
    }
  }
}