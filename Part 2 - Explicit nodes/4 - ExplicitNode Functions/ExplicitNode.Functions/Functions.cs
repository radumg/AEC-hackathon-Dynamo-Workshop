using Autodesk.DesignScript.Runtime;

namespace DynamoWorkshop.ExplicitNode.Functions
{
  [IsVisibleInDynamoLibrary(false)]
  public static class Functions
  {
    public static double MultiplyTwoNumbers(double a, double b)
    {
      return a * b;
    }
  }
}
