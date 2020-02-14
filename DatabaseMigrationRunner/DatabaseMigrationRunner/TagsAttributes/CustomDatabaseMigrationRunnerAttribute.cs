using FluentMigrator;

namespace DatabaseMigrationRunner.TagsAttributes
{
  /// <summary>
  /// Custom Database Migration Runner Attribute
  /// </summary>
  /// <seealso cref="FluentMigrator.MigrationAttribute" />
  public class CustomDatabaseMigrationRunnerAttribute : MigrationAttribute
  {
    public CustomDatabaseMigrationRunnerAttribute(int release, int sprint, int year, int month, int day, int hour, int minute, string description, string author = null) : base(CalculateValue(release, sprint, year, month, day, hour, minute), GetDescription(author, description))
    {
      this.Author = author;
    }

    public string Author { get; private set; }

    public static long CalculateValue(int release, int sprint, int year, int month, int day, int hour, int minute)
    {
      return release * 10000000000000L +
              sprint * 100000000000L +
              year * 100000000L +
              month * 1000000L +
              day * 10000L +
              hour * 100L +
              minute;
    }

    public static string GetDescription(string author, string description)
    {
      if (string.IsNullOrWhiteSpace(author))
      {
        return description;
      }

      return string.Concat(author, " - ", description);
    }
  }
}