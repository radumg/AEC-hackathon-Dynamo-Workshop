using Autodesk.DesignScript.Runtime;
using Autodesk.DesignScript.Geometry;
using System.Collections.Generic;


namespace DynamoUnchained.ZeroTouch
{
  /// <summary>
  /// Sample ZTN Library
  /// </summary>
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

    public static double AverageNumbers(double Number1, double Number2)
    {
      return (Number1 + Number2) / 2;
    }

    [MultiReturn(new[] { "evens", "odds" })]
    public static Dictionary<string, object> SplitOddEven(List<int> list)
    {
      var odds = new List<int>();
      var evens = new List<int>();

      //check integers in list if even or odd
      foreach (var i in list)
      {
        if (i % 2 == 0)
        {
          evens.Add(i);
        }
        else
        {
          odds.Add(i);
        }
      }

      //create a new dictionary and return it
      var d = new Dictionary<string, object>();
      d.Add("evens", evens);
      d.Add("odds", odds);
      return d;

      //the above can be simplified in one line with
      //return new Dictionary<string, object> { { "evens", evens }, { "odds", odds } };       
    }

    public static Line ByCoordinates(double X1, double Y1, double Z1, double X2, double Y2, double Z2)
    {
      var p1 = Point.ByCoordinates(X1, Y1, Z1);
      var p2 = Point.ByCoordinates(X2, Y2, Z2);
      var l = Line.ByStartPointEndPoint(p1, p2);
      p1.Dispose();
      p2.Dispose();
      return l;
    }

  }
}
