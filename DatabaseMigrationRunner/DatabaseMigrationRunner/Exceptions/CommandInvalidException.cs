using System;

namespace DatabaseMigrationRunner.Exceptions
{
  [Serializable]
  public class CommandInvalidException : Exception
  {
    public CommandInvalidException(string argName, string argValue)
        : base(string.Format("Passed Arguments are not valid, Please Provide Proper Value!!! Argument Name: {0} Value: {1}", argName, argValue))
    {
    }

    public CommandInvalidException(string errorMessage)
        : base(errorMessage)
    {
    }
  }
}