using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace DynamoWorkshop.ZeroTouch
{
    public static class Exceptions
    {
        /// <summary>
        /// Throws an Exception if the text is null and returns if if not.
        /// </summary>
        /// <param name="text">The text to test.</param>
        /// <returns>Throws if null and returns original text if not.</returns>
        public static string ThrowExceptionIfStringIsNull(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentNullException("text");
            return text;
        }

        /// <summary>
        /// Calculate sum of all list members but handle nulls internally.
        /// </summary>
        /// <param name="list">The list to sum up.</param>
        /// <returns>The total sum of list.</returns>
        public static int HandleListNullExceptionsInternally(List<object> list)
        {
            // check input list is not empty
            if (list == null || list.Count < 1) throw new ArgumentNullException("list");
            var sum = 0;

            foreach (var item in list)
            {
                try
                {
                    // it's safe to throw inside a try block as the exception will be caught below
                    if (item == null) throw new NullReferenceException();

                    // if the object cannot be converted to an integer, this will throw an exception as well
                    int intValue = Convert.ToInt32(item);

                    // this only executes if the above checks did not throw
                    sum += intValue;
                }
                catch (Exception)
                {
                    // this block of code would be executed whenever a null is found in the list
                }
            }

            return sum;
        }
    }
}
