using Autodesk.DesignScript.Runtime;
using Autodesk.DesignScript.Geometry;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DynamoWorkshop.ZeroTouch
{

    public static class Output
    {
        /// <summary>
        /// Splits odd and even elements from a list into two separate lists.
        /// </summary>
        /// <param name="list">The list to split.</param>
        /// <returns>The two lists containing only even and odd numbers respectively.</returns>
        [MultiReturn(new[] { "evens", "odds" })]
        public static Dictionary<string, object> SplitOddEven(List<int> list)
        {
            // check input list is not empty
            if (list == null || list.Count < 1) throw new ArgumentNullException("list");

            // allocate the two new lists that will hold the odd and even values
            var odds = new List<int>();
            var evens = new List<int>();

            //check if integers in list are even or odd and add to respective list
            foreach (var item in list)
            {
                if (item % 2 == 0)
                {
                    evens.Add(item);
                }
                else
                {
                    odds.Add(item);
                }
            }

            //create a new dictionary and return it
            var dict = new Dictionary<string, object>();
            dict.Add("evens", evens);
            dict.Add("odds", odds);
            return dict;

            //the above can be simplified in one line with
            //return new Dictionary<string, object> { { "evens", evens }, { "odds", odds } };       
        }
    }
}
