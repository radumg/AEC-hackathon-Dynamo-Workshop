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

namespace DynamoWorkshop.ZeroTouch
{
    public static class HelloRevit
    {
        public static Autodesk.DesignScript.Geometry.Curve GetWallBaseline(Revit.Elements.Wall wall)
        {
            //get Revit Wall element from the Dynamo-wrapped object
            var revitWall = wall.InternalElement;
            //get the location curve of the wall using the Revit API
            var locationCurve = revitWall.Location as LocationCurve;
            //convert the curve to Dynamo and return it
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
        public static IEnumerable<Revit.Elements.Wall> SayHello(
            string text,
            double height,
            Revit.Elements.Level level,
            Revit.Elements.WallType wallType,
            int size = 25
            )
        {
            //first check inputs
            if (level == null) throw new ArgumentNullException("level");
            if (wallType == null) throw new ArgumentNullException("wallType");

            // allocate a new list to hold the Revit walls we create
            var walls = new List<Revit.Elements.Wall>();

            // convert the text to Dynamo lines using our utility function
            var lines = TextUtils.TextToLines(text, size);

            // remember : elements creation and modification has to be inside of a transaction
            TransactionManager.Instance.EnsureInTransaction(Document);

            foreach (var curve in lines)
            {
                // we can't skip null curves so let's check for this
                if (curve == null)  throw new ArgumentNullException("curve");

                try
                {
                    // now let's create the wall in Revit
                    var wall = Autodesk.Revit.DB.Wall.Create(
                        Document, // the current Revit document
                        curve.ToRevitType(), // the curve to create wall on, note we need to convert Dynamo curves to Revit types
                        wallType.InternalElement.Id, // Revit elements returned from Dynamo are wrapped, so we need to access the internal element directly
                        level.InternalElement.Id, // the level to base this wall at
                        height, // the unconnected height of the wall
                        0.0, // the offset
                        false, // flip or not
                        false // structural or not
                        );

                    // then add this to our list of new Revit walls
                    walls.Add(wall.ToDSType(false) as Revit.Elements.Wall);
                }
                catch (Exception ex)
                {
                    // if something went wrong when creating the Revit wall, 
                    // raise an exception so the error is surfaced in Dynamo
                    throw new ArgumentException(ex.Message);
                }

            }
            // we need to close the transaction, telling Revit we are done with creating and modifying elements
            TransactionManager.Instance.TransactionTaskDone();

            // finally, let's return our walls.
            return walls;
        }

        internal static Autodesk.Revit.DB.Document Document
        {
            get { return DocumentManager.Instance.CurrentDBDocument; }
        }
    }
}
