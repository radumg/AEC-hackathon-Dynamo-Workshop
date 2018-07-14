using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using Autodesk.Revit.DB; //Revit API
using Revit.Elements; //Dynamo Revit Elements
using Autodesk.DesignScript.Geometry; //Dynamo Geometry
using RevitServices.Persistence;
using RevitServices.Transactions;
using Revit.GeometryConversion;


namespace DynamoUnchained.ZeroTouch
{
  public static class HelloRevit
  {
    public static Autodesk.DesignScript.Geometry.Curve GetWallBaseline(Revit.Elements.Wall wall)
    {
      //get Revit Wall
      var revitWall = wall.InternalElement;
      //revit API
      var locationCurve =  revitWall.Location as LocationCurve;
      //convert to Dynamo and return it
      return locationCurve.Curve.ToProtoType();
    }


    //bits and pieces from https://github.com/DynamoDS/DynamoRevit/blob/Revit2017/src/Libraries/RevitNodes/Elements/Wall.cs
    /// <summary>
    /// Say Hello, generates Revit walls based on an input text as driving curve
    /// </summary>
    /// <param name="text">Text to cenvert into Wall baselines</param>
    /// <param name="height">Wall Height</param>
    /// <param name="level">Wall Level</param>
    /// <param name="wallType">Wall Type</param>
    /// <param name="size">Font Size</param>
    /// <returns></returns>
    public static IEnumerable<Revit.Elements.Wall> SayHello(string text, double height, Revit.Elements.Level level, Revit.Elements.WallType wallType, int size = 25)
    {
      //first check inputs
      if (level == null)
      {
        throw new ArgumentNullException("level");
      }

      if (wallType == null)
      {
        throw new ArgumentNullException("wallType");
      }

      var walls = new List<Revit.Elements.Wall>();
      var lines = TextUtils.TextToLines(text, size);

      //elements creation and modification has to be inside of a transaction
      TransactionManager.Instance.EnsureInTransaction(Document);

      foreach (var curve in lines)
      {
        if (curve == null)
        {
          throw new ArgumentNullException("curve");
        }
      
        try
        {
          var wall = Autodesk.Revit.DB.Wall.Create(Document, curve.ToRevitType(), wallType.InternalElement.Id, level.InternalElement.Id, height, 0.0, false, false);
          walls.Add(wall.ToDSType(false) as Revit.Elements.Wall);
        }
        
        catch(Exception ex)
        {
          throw new ArgumentException(ex.Message);
        }
        
      }

      TransactionManager.Instance.TransactionTaskDone();

      return walls;
    }

    internal static Autodesk.Revit.DB.Document Document
    {
      get { return DocumentManager.Instance.CurrentDBDocument; }
    }
  }
}
