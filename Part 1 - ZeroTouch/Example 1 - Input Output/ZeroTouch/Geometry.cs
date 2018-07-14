using Autodesk.DesignScript.Geometry;

namespace DynamoWorkshop.ZeroTouch
{
    public static class Geometry
    {
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
