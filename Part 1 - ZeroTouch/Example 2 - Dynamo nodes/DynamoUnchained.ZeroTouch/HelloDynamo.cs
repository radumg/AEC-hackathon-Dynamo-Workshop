using Autodesk.DesignScript.Runtime;
using Autodesk.DesignScript.Geometry;
using System.Collections;
using System.Collections.Generic;

namespace DynamoUnchained.ZeroTouch
{

  public static class HelloDynamo
  {
    public static string SayHello(string Name)
    {
      return "Hello " + Name + "!";
    }

    public static double AverageNumbers(double Number1, double Number2)
    {
      return (Number1 + Number2) / 2;
    }

    public static IList AddItemToEnd([ArbitraryDimensionArrayImport] object item, IList list)
    {
      //Clone original list
      return new ArrayList(list)
      {
        //Add item to the end of cloned list
        item
      };
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

    [MultiReturn(new[] { "X", "Y", "Z" })]
    public static Dictionary<string, object> PointCoordinates(Point point)
    {
      return new Dictionary<string, object> {{ "X", point.X }, { "Y", point.Y}, { "Z", point.Z } };
    }

    public static Line ByCoordinates(double X1, double Y1, double Z1, double X2, double Y2, double Z2)
    {
      using (var p1 = Point.ByCoordinates(X1, Y1, Z1))
      {
        using (var p2 = Point.ByCoordinates(X2, Y2, Z2))
        {
          return Line.ByStartPointEndPoint(p1, p2);
        }
      }
    }
  }
}
