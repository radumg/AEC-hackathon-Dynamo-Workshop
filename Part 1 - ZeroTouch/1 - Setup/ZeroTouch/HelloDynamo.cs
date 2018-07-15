using Autodesk.DesignScript.Runtime;
using Autodesk.DesignScript.Geometry;
using System.Collections.Generic;

/// <summary>
/// Starter ZeroTouch library for Dynamo 2.0.1
/// </summary>
namespace DynamoWorkshop.ZeroTouch
{
  public static class HelloDynamo
  {
    /// <summary>
    /// Prints a friendly greeting
    /// </summary>
    /// <param name="Name">Name of the person to greet</param>
    /// <returns>A greeting</returns>
    public static string SayHello(string Name)
    {
      return "Hello " + Name + "!";
    }
  }
}
