using Autodesk.DesignScript.Runtime;
using System.Collections;

namespace DynamoWorkshop.ZeroTouch
{
    public static class Input
    {
        /// <summary>
        /// Calculate the average between two numbers.
        /// </summary>
        /// <param name="Number1">The first number</param>
        /// <param name="Number2">The second number</param>
        /// <returns>The arithmetic average between the two numbers.</returns>
        public static double AverageNumbers(double Number1, double Number2)
        {
            return (Number1 + Number2) / 2;
        }

        /// <summary>
        /// Deletes all the contents of a list.
        /// </summary>
        /// <param name="list">The list to clear.</param>
        /// <returns>The cleared list</returns>
        public static IList ClearListContents(IList list)
        {
            list.Clear();
            return list;
        }

        /// <summary>
        /// Add an item to the end of a list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="list">The list.</param>
        /// <returns>The list with the item added at the end.</returns>
        public static IList AddItemToEnd([ArbitraryDimensionArrayImport] object item, IList list)
        {
            //Clone original list
            return new ArrayList(list)
              {
                //Add item to the end of cloned list
                item
              };
        }
    }
}
