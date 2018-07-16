using Autodesk.DesignScript.Geometry;

namespace DynamoWorkshop.ZeroTouch
{
    /// <summary>
    /// Class to demonstrate the creation & handling of geometry using the Dynamo API
    /// </summary>
    public static class Geometry
    {
        /// <summary>
        /// Deconstruct a point into its X,Y,Z coordinates
        /// </summary>
        /// <param name="point">The point to deconstruct</param>
        /// <returns>Individual X,Y,Z coordinate values</returns>
        [MultiReturn(new[] { "X", "Y", "Z" })]
        public static Dictionary<string, object> DeconstructPoint(Point point)
        {
            return new Dictionary<string, object> {
                { "X", point.X },
                { "Y", point.Y },
                { "Z", point.Z }
            };
        }

        /// <summary>
        /// Create a line from a pair of X,Y,Z coordinates
        /// </summary>
        /// <param name="X1">start point X</param>
        /// <param name="Y1">start point Y</param>
        /// <param name="Z1">start point Z</param>
        /// <param name="X2">end point X</param>
        /// <param name="Y2">end point Y</param>
        /// <param name="Z2">end point Z</param>
        /// <returns>A new line</returns>
        public static Line LineByCoordinatesPair(double X1, double Y1, double Z1, double X2, double Y2, double Z2)
        {
            // build the start/end Dynamo points from the coordinates
            var startPoint = Point.ByCoordinates(X1, Y1, Z1);
            var endPoint = Point.ByCoordinates(X2, Y2, Z2);

            // use Dynamo API to build a line between these two points
            var newLine = Line.ByStartPointEndPoint(startPoint, endPoint);

            // IMPORTANT : don't forget to dispose of geometry you create in nodes !!
            startPoint.Dispose();
            endPoint.Dispose();

            // return the created line
            return newLine;
        }
    }
}
