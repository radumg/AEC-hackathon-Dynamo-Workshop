using System;

namespace DynamoWorkshop.ZeroTouch
{
    /// <summary>
    /// Sample ZeroTouch Nodes (ZTN) Library that has no external dependencies.
    /// </summary>
    public class ExampleZeroTouchClass
    {
        /// <summary>
        /// This property is public and hence visible in Dynamo as a node.
        /// This displays in Dynamo as a Query node, identified with a blue ? icon.
        /// </summary>
        public string ZeroTouchPublicProperty { get; set; }

        /// <summary>
        /// This property will not be visible in Dynamo because it is not public.
        /// </summary>
        static string ZeroTouchPrivateProperty { get; set; }

        /// <summary>
        /// The constructor for this class.
        /// This will not be visible in Dynamo as a node as it is not public, so static constructors have to be used instead.
        /// Marking this as public will make an empty node appear in Dynamo.
        /// </summary>
        ExampleZeroTouchClass()
        {
            ZeroTouchPublicProperty = "The value of this property is set in the class constructor";
            ZeroTouchPrivateProperty = "This will never show up in Dynamo.";
        }

        /// <summary>
        /// This static method will return a new instance of the ExampleZeroTouchClass, with the ZeroTouchPublicProperty set to the text provided.
        /// This displays in Dynamo as a Constructor node, identified with a green + icon.
        /// </summary>
        /// <param name="text">The ZeroTouchPublicProperty will be set to the text provided here.</param>
        /// <returns>A new instance of a ExampleZeroTouchClass object</returns>
        public static ExampleZeroTouchClass ByUserTextConstructor(string text)
        {
            var newInstance = new ExampleZeroTouchClass();
            newInstance.ZeroTouchPublicProperty = text;

            return newInstance;
        }

        /// <summary>
        /// Update the ZeroTouchPublicProperty of this ExampleZeroTouchClass.
        /// This displays in Dynamo as an Action node, identified with a red thunderbolt icon, exciting!
        /// Because this method is not static, notice how Dynamo adds another input to the resulting node, asking for an instance of ExampleZeroTouchClass.
        /// </summary>
        /// <param name="text">The text to update the ZeroTouchPublicProperty to.</param>
        /// <returns>The updated instance of ExampleZeroTouchClass that was supplied.</returns>
        public ExampleZeroTouchClass UpdatePublicPropertyAction(string text)
        {
            this.ZeroTouchPublicProperty = text;
            return this;
        }

        /// <summary>
        /// This public static method returns a random number every time it's executed.
        /// Notice how the node Dynamo creates does not require an instance of an ExampleZeroTouchClass as input.
        /// </summary>
        /// <returns>A random integer.</returns>
        public static int GetRandomNumberFromAStaticMethod()
        {
            return new Random().Next();
        }
    }
}
