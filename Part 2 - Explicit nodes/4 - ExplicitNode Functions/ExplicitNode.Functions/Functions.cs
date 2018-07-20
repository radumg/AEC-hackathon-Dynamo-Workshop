using Autodesk.DesignScript.Runtime;
using System.Drawing;

namespace DynamoWorkshop.ExplicitNode.Functions
{
  [IsVisibleInDynamoLibrary(false)]
  public static class Functions
  {
    public static DSCore.Color ColorByARGB(int a, int r, int g, int b)
    {
      return DSCore.Color.ByARGB(a, r, g, b);
    }
  }
}
