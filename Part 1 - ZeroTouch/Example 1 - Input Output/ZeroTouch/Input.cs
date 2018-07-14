using Autodesk.DesignScript.Runtime;
using System.Collections;

namespace DynamoWorkshop.ZeroTouch
{
    public static class Input
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
        /// Returns the unique hash code of a list. 
        /// Can be used to compare if two lists are identical.
        /// </summary>
        /// <param name="list">The list to generate hash for.</param>
        /// <returns>The unique hash as an integer.</returns>
        public static int GetListHashCode(IList list)
        {
            return list.GetHashCode();
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
