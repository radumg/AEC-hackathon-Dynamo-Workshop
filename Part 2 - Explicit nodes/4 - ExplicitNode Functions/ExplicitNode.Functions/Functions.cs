using Autodesk.DesignScript.Runtime;
using System.Drawing;

namespace DynamoWorkshop.ExplicitNode.Functions
{
  [IsVisibleInDynamoLibrary(false)]
  public static class Functions
  {
    public static Color ColorByARGB(int a, int r, int g, int b)
    {
      return Color.FromArgb(a, r, g, b);
    }
  }
}
