using System;
using System.Collections;

namespace CSharp
{
    class Collections
    {
        /*
         generic containers are often favored over their nongeneric counterparts because they typically provide greater 
         type safety and performance benefits

        a collection class can belong to one of two broad categories:
            • Nongeneric collections (primarily found in the System.Collections namespace)
            • Generic collections (primarily found in the System.Collections.Generic namespace)

        Nongeneric collections are typically designed to operate on System.Object types (thus not type safe) and are, therefore,
        loosely typed containers (however, some nongeneric collections do operate only on a specific type of data,
        such as string objects). In contrast, generic collections are much more type safe, given that you must specify
        the “type of type” they contain upon creation.

        It is important to point out that a majority of your .NET projects will most likely not make
        use of the collection classes in the System.Collections namespace! To be sure, these days it is far more
        common to make use of the generic counterpart classes found in the System.Collections.Generic namespace
         */

        public static void nonGenericCollectionsDemo()
        {
            ArrayList strArray = new ArrayList();
            strArray.AddRange(new string[] { "1st entry", "2nd entry" });

            // Show number of items in ArrayList.
            Console.WriteLine("This collection has {0} items.", strArray.Count);
            Console.WriteLine();

            // Add a new item and display current count.
            strArray.Add("4th entry");
            Console.WriteLine("This collection has {0} items.", strArray.Count);

            // Display contents.
            foreach (string s in strArray)
            {
                Console.WriteLine("Entry: {0}", s);
            }
            Console.WriteLine();

            //Boxing and unboxing
            /*
            Boxing can be formally defined as the process of explicitly assigning a value type to a System.Object
            variable. When you box a value, the CLR allocates a new object on the heap and copies the value type’s
            value (25, in this case) into that instance. What is returned to you is a reference to the newly allocated
            heap-based object.

            Unboxing is the process of converting the value held in the object reference back into a corresponding value type on the stack. 
             
            Since containers in System.Collectios are based on System.Object, even the 
            */

            // Make a ValueType (int) variable.
            int myInt = 25;
            // Box the int into an object reference.
            object boxedInt = myInt;

            try
            {
                // Unbox the reference back into a corresponding int.
                int unboxedInt = (int)boxedInt;  //If you attempt to unbox a piece of data into the incorrect data type, an InvalidCastException exception will be thrown
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine(e.StackTrace);
            }

            // Value types are automatically boxed when passed to a method requesting an object.
            ArrayList myInts = new ArrayList();
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);

            //you must unbox the heap-allocated object into a stack-allocated integer using a casting operation
            int i = (int) myInts[1];

            /*
            Boxing and unboxing are convenient from a programmer’s viewpoint, but this simplified approach to
            stack/heap memory transfer comes with the baggage of performance issues (in both speed of execution and
            code size) and a lack of type safety.
            
            To understand the performance issues, ponder the steps that must occur to box and unbox a simple integer :
                1. A new object must be allocated on the managed heap.
                2. The value of the stack-based data must be transferred into that memory location.
                3. When unboxed, the value stored on the heap-based object must be transferred back to the stack.
                4. The now unused object on the heap will (eventually) be garbage collected.
             */
        }
    }
}
