//Onenote : Read everything before (including) Namespace in C#

using System;
using System.Text;
using CSharp.Interface;
using CSharp.Interface.Common_Interfaces_Implementation;

namespace CSharp
{
    class Program
    {
        /* program execution starts from Main method (assuming it is contained within a C# class or structure definition). 
        Formally speaking, the class that defines the Main() method is termed the application object.
        
        While it is possible for a single executable application to have more than one application object (which can be useful
        when performing unit tests), you must inform the compiler which Main() method should be used as the
        entry point via the /main option of the command-line compiler or via the Startup Object drop- down list box,
        located on the Application tab of the Visual Studio project properties editor 

        Main must be declared as static and it must return void or int, and it must have either no parameters or else one parameter of type string[].        
        
        No need of an explicit return statement when method has void return type. If no access modifier is used, private is assumed
        
         Onenote : Specifying an Application Error Code in C#*/
        static int Main(string[] args)
        {
            //use Environment.GetCommandLineArgs() to get command line args passed, args passed on to Main can be used as well
            Console.WriteLine("Number of command line args = {0}", Environment.GetCommandLineArgs().Length);

            //basics();
            //OOP();
            //ExceptionHandling.exceptionHandlingMain();
            //iterfaceImplementationDemo();

            Collections.nonGenericCollectionsDemo();

            Console.Write("\nType anythng and press enter to exit : ");
            System.Console.ReadLine();      //fully qualified name
            return -1;      // return an application error code of -1
        }

        static void basics()
        {
            //********** Basic Features :

            //formattingOutput();
            //onenote : Fundamental Data Types of C#
            //typeVariablesAndStrings();
            //checkedKeywordOverflowException();
            //implicitlyTypedLocalVar();
            //loops();
            //onenote : Parameter modifiers
            //array();
            WeekendDays weekEndDays = WeekendDays.Sun;
            //enumDemo(weekEndDays);
            //structDemo();
        }

        static void OOP()
        {
            //********** OOP :

            Car car = new Car("Toyota");
            car.displayInfo();
            //Console.WriteLine("Car description is : {0}", car.objectDescription);   //static data cannot be accessed by objetc / instance of a class
            // Take a look at Car.cs
            // Onenote : Access Modifiers

            /*TOPIC : Object Initialization Syntax
              
             When you are working with other people’s classes, including the classes found within the .NET base class library, it
            is not too uncommon to discover that there is not a single constructor that allows you to set every piece of underlying state data. 
            
             To help streamline the process of getting an object up and running, C# offers object initializer syntax.
            Using this technique, it is possible to create a new object variable and assign a slew of properties and/or
            public fields in a few lines of code.
            
             NOTE : Static data cannot be initialized with the syntax below*/
            Car car1 = new Car { MaxCapacity = 10 };    // the parameterless constructor is called implicitly
            Car car2 = new Car() { MaxCapacity = 5, NumberOfWheels = 4 };   // the parameterless constructor is called explicitly
            Car car3 = new Car("Honda") { MaxCapacity = 8 };    // a custom constructor is called

            // Onenote : partial classes

            // Take a look at MiniVan.cs

            Console.WriteLine("\n*** Before first MiniVan object is created in OOP() ***\n");
            MiniVan miniVan = new MiniVan();
            //creating an object of inner class
            MiniVan.PublicInnerClass publicInnerClassObject = new MiniVan.PublicInnerClass();

            // Onenote : Virtual properties and methods
            // Onenote : Polymorphism
            // Onenote : Interfaces (also take a look at interface folder)

            Triangle t = new Triangle();

            // use the is and as keyword to determine if a (objetc of) class implements an interface
            // below, we check if a Triangle class object implements Point
            CSharp.Interface.IPoint p = t as CSharp.Interface.IPoint;
            if(p != null)
            {
                p.NumOfPoints = 3;      
            }

            if(t is CSharp.Interface.IPoint)      
            {
                Console.WriteLine("Now safe to cast Triangle objects to Point type");
            }

            IPoint pp = t as IPoint;

            //Onenote : System.Object

            String c = "hey there !";
            String c1 = "hey there !";
       
            Console.WriteLine("{0} , {1}", c.GetHashCode(), c1.GetHashCode()) ;
        }

        static void iterfaceImplementationDemo()
        {
            //Enumerable.demo();
            //Cloneable.demo();
            //Comparable.demo();
        }

        static void formattingOutput()
        {
            Console.WriteLine("\n****** FormattingOutput() *******\n");
            Console.WriteLine("Your name is {0} and still, your name is {0}", "dummy");
            Console.WriteLine("the numbers are {1}, {2}, {0}", 4, 5, 6);

            //Fromat numerical output:

            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);
            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);     // Notice that upper- or lowercasing for hex determines if letters are upper- or lowercase.
            Console.WriteLine("x format: {0:x}", 99999);

            // if you are interested in digging into .NET string formatting further, look up the topic “Formatting Types” within the
            //.NET Framework 4.6 SDK documentation. Can also look up "Formatting Numeric Results Table"

            // Using string.Format() to format a string literal.
            string userMessage = string.Format("100000 in hex is {0:x}", 100000);
            Console.WriteLine("userMessage is : " + userMessage);
        }

        static void typeVariablesAndStrings()
        {
            Console.WriteLine("\n****** typeVariables() *******\n");

            bool b1 = false, b2 = true, b3, b4 = b1;
            //Console.WriteLine("b3 is : {0}", b3);   // local variables need to be initalized before use !
            int i = new int();      // set i to default int value, which is 0
            //2 ways of formatting strings
            Console.WriteLine("literals are objects ! , 123.GetType() = {0}", 123.GetType());
            Console.WriteLine($"literals are objects ! , 123.GetType() = {123.GetType()}");     // called string Interpolation
            Console.WriteLine($"i = 0; ++i = {++i}");

            //Object type var
            Object o = 232;
            Console.WriteLine($"o type = {o.GetType()}");  // will print out "o type = System.Int32", GetType() gives fully qualified type name

            //some members of numerical types
            Console.WriteLine("\nMax of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity: {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfinity: {0}", double.NegativeInfinity);

            //some members of char types
            Console.WriteLine("\nchar.IsDigit('a'): {0}", char.IsDigit('a'));
            Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter('a'));

            //parsing values from string data using static Parse() method
            bool b = bool.Parse("True");
            Console.WriteLine("\nValue of b: {0}", b);
            double d = double.Parse("99.884");
            Console.WriteLine("Value of d: {0}", d);
            int ii = int.Parse("8");
            Console.WriteLine("Value of ii: {0}", ii);
            char c = Char.Parse("w");
            Console.WriteLine("Value of c: {0}", c);

            // Using verbatim strings, you disable the processing of a literal’s escape characters and print out a string as is
            Console.WriteLine(@"C:\MyApp\bin\Debug");
            // White space is preserved with verbatim strings.
            string myLongString = @"This is a very
                                    very
                                    very
                                    long string";
            Console.WriteLine(myLongString);
            // Using verbatim strings, you can also directly insert a double quote into a literal string by doubling the " token.
            Console.WriteLine(@"Cerebus said ""Darrr! Pret-ty sun-sets""");

            /*
            StringBuilder is in System.Text namespace

            What is unique about the StringBuilder is that when you call members of this type, you are directly
            modifying the object’s internal character data (making it more efficient), not obtaining a copy of the data in
            a modified format. 

            By default, a StringBuilder is only able to initially hold a string of 16 characters or fewer (but will expand 
            automatically if necessary).

            If you append more characters than the specified limit, the StringBuilder object will copy its data into a new instance 
            and grow the buffer by the specified limit. Thus, for efficiency purpose, choose best estimate for buffer size
            */

            // Make a StringBuilder with an initial size of 256.
            StringBuilder sb = new StringBuilder("\nFantastic Games !", 256);
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
        }

        static void checkedKeywordOverflowException()
        {
            /*      
            the default behavior of the .NET runtime is to ignore arithmetic overflow/underflow

            C# provides the checked keyword. When you wrap a statement (or a block of statements)
            within the scope of the checked keyword, the C# compiler emits additional CIL instructions that test for overflow
            conditions that may result when adding, multiplying, subtracting, or dividing two numerical data types.
            If an overflow has occurred, you will receive a runtime exception: System.OverflowException. 
            */
            Console.WriteLine("\n****** checkedKeywordOverflowException() *******\n");

            byte b1 = 100;
            byte b2 = 250;

            // This time, tell the compiler to add CIL code
            // to throw an exception if overflow/underflow
            // takes place.
            try
            {
                byte sum = checked((byte)(b1 + b2)); // only checks computations within scope of checked,
                Console.WriteLine("sum = {0}", sum);  //(in our case, only addition b1 + b2 and subsequent conversion to byte which results in overflow)
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Exception from first try catch block : " + ex.Message);
            }

            //If you want to force overflow checking to occur over a block of code statements, you can do so by
            //defining a “checked scope” as follows:
            try
            {
                checked           //check for overflow withing scope of checked statement (this time covering multiple lines of code)
                {
                    byte sum = (byte)(b1 + b2);
                    Console.WriteLine("sum = {0}", sum);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Exception from second try catch block : " + ex.Message);
            }

            /*
            If you are creating an application that should never allow silent overflow to occur, you might find yourself in
            the annoying position of wrapping numerous lines of code within the scope of the checked keyword. As an
            alternative, the C# compiler supports the /checked flag. When enabled, all your arithmetic will be evaluated
            for overflow without the need to make use of the C# checked keyword. If overflow has been discovered, you
            will still receive a runtime exception.

            To enable this flag using Visual Studio, open your project’s property page and click the Advanced button
            on the Build tab. From the resulting dialog box, select the “Check for arithmetic overflow/underflow” check box   
            
            Enabling this setting can be helpful when you’re creating a debug build. After all the overflow
            exceptions have been squashed out of the code base, you’re free to disable the /checked flag for subsequent
            builds (which can increase the runtime performance of your application). 
            */

            /*
             Now, assuming you have enabled this project-wide setting, what are you to do if you have a block of code
            where data loss is acceptable? Given that the /checked flag will evaluate all arithmetic logic, C# provides
            the unchecked keyword to disable the throwing of an overflow exception on a case-by-case basis. This
            keyword’s use is identical to that of the checked keyword in that you can specify a single statement or a block
            of statements.
            */

            //*** Imp assumption : Assuming /checked (program wide overflow checking described above enabled in settings) is enabled,
            // this block will not trigger a runtime exception.
            unchecked
            {
                byte sum = (byte)(b1 + b2);
                Console.WriteLine("sum = {0} ", sum);
            }
        }

        static void implicitlyTypedLocalVar()
        {
            /*
              C# language does provide for implicitly typing of local variables using the
            var keyword. The var keyword can be used in place of specifying a specific data type (such as int, bool, or
            string). When you do so, the compiler will automatically infer the underlying data type based on the initial
            value used to initialize the local data point. 
             */

            Console.WriteLine("\n*** From implicitlyTypedLocalVar() ***");

            // Implicitly typed local variables.
            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";
            // Print out the underlying type.
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
            Console.WriteLine("myString is a: {0}", myString.GetType().Name);

            //Onenote : Restrictions on Implicitly typed variables (var)
        }

        static void loops()
        {
            int i = 1;

            //if statements
            /*Unlike in C and C++, the if/else statement in C# operates only on
            Boolean expressions, not ad hoc values such as –1 or 0.*/
            if (i == 1)
            {
                Console.WriteLine("i is 1");
            }
            else if (i == 2)
            {
                Console.WriteLine("i is 2");
            }
            else
            {
                Console.WriteLine("i is something else");
            }

            //for loop, contine, break
            for (int ii = 0, j = 4; i < 4; i++, j--)
            {
                if (ii == 1)
                    continue;

                if (ii == 3)
                    break;

                Console.WriteLine($"Number is: {i} {j}");
            }

            String[] data = { "this", "is", "it" };
            //foreach
            foreach (String s in data)
                Console.WriteLine(s);

            //switch and goto : cases in C# need to end with break or goto !
            //C# demands that each case (including default) that contains executable statements have a
            //terminating break or goto to avoid fall-through
            int caseSwitch = 2;
            switch (caseSwitch)
            {
                case 1:     //case value needs to be a constant, enums can be used !
                    Console.WriteLine("Case 1");
                    break;
                case 3:
                case 2:
                    Console.WriteLine("Case 2 or case 3");
                    goto default;       // ***** goto statement
                default:
                    Console.WriteLine("Default case");
                    break;          // even the default case need to end with break or goto
            }

            //while loop
            i = 2;
            while (i != 4)
            {
                Console.WriteLine("From while loop, i = {0}", i++);
            }

            //do while loop
            do
            {
                Console.WriteLine("From do while loop, i = {0}", i);
            } while (i != 4);
        }

        static void array()
        {
            Console.WriteLine("\n**** array() ***");

            int[] intArray = new int[3];    // individual elements initialized to default value, 0 in case of int
            intArray[2] = 12;

            int j = 0;
            foreach (int i in intArray) Console.WriteLine($"intArray[{j++}] = " + i);

            //ways to initilaize an array

            //specifying new kewyord is optional, use this one as it involves less typing !
            bool[] boolArray = { false, false, true };
            Console.WriteLine("\nboolArray has {0} elements", boolArray.Length);

            //specifying length is optional
            string[] stringArray = new string[] { "one", "two", "three" };
            Console.WriteLine("stringArray has {0} elements", stringArray.Length);

            // number of elements in { } shall be equal to length specified in []
            int[] intArray1 = new int[4] { 20, 22, 23, 0 };
            Console.WriteLine("intArray1 has {0} elements", intArray1.Length);

            // Make an array of Shape-compatible objects : Shape is base class and all other are derived class
            //Shape[] myShapes = {new Hexagon(), new Circle(), new Hexagon("Mick"), new Circle("Beth"), new Hexagon("Linda")};

            // implicitly typed array

            // a is really int[].
            var a = new[] { 1, 10, 100, 1000 };     // need to use new
            Console.WriteLine("\na is a: {0}", a.GetType());
            // b is really double[].
            var b = new[] { 1, 1.5, 2, 2.5 };
            Console.WriteLine("b is a: {0}", b.ToString());
            // c is really string[].
            var c = new[] { "hello", null, "world" };
            Console.WriteLine("c is a: {0}", c.ToString());

            // Error! Mixed types!
            //var d = new[] { 1, "one", 2, "two", false };

            // explicitly specifying the type, which kinda defeats the purpose of using an implicitly typed variable
            var d = new Object[] { 1, 12.21, "test" };
            Console.WriteLine("d is a: {0}", d.ToString());

            /*
            C# also supports two varieties of multidimensional arrays. 

            The first of these is termed a rectangular array, which is simply an array of multiple dimensions, where each 
            row is of the same length. To declare and fill a multidimensional rectangular array, proceed as follows:
            */
            int[,] myMatrix = new int[3, 4];

            //The second type of multidimensional array is termed a jagged array. As the name implies, jagged arrays
            //contain some number of inner arrays, each of which may have a different upper limit. 
            int[][] myJagArray = new int[5][];

            for (int i = 0; i < myJagArray.Length; i++)
                myJagArray[i] = new int[i + 7];

            /*
             Every array you create gathers much of its functionality from the System.Array class
             
            Select Members of System.Array:

            Member of Array                                         Class Meaning in Life
            Clear()                         This static method sets a range of elements in the array to empty values (0 for
                                            numbers, null for object references, false for Booleans).
            CopyTo()                        This method is used to copy elements from the source array into the destination
                                            array.
            Length                          This property returns the number of items within the array.
            Rank                            This property returns the number of dimensions of the current array.
            Reverse()                       This static method reverses the contents of a one-dimensional array.
            Sort()                          This static method sorts a one-dimensional array of intrinsic types (types built into C#). If the
                                            elements in the array implement the IComparer interface, you can also sort your
                                            custom types (see Chapter 9).
             */
        }

        /*enums gain functionality from the System.Enum class type. Check out their member class and properties !
         * 
         * The enum keyword is used to declare an enumeration, a distinct type that consists of a set of named constants.
        Usually it is best to define an enum directly within a namespace so that all classes in the namespace can access it with equal convenience. 
        However, an enum can also be nested within a class or struct.
        By default, the first enumerator has the value 0, and the value of each successive enumerator is increased by 1. 

        enum WorkingDays { Mon, Tue, Wed = 44, Thu, Fri };  //Thu is 45, Fri is 46
        // members of enum type can be accessed as follows : enumType.member ex : WorkingDays.Fri

        /*Every enumeration type has an underlying type, which can be any integral type except char. 
         * The default underlying type of enumeration elements is int.
         The approved types for an enum are byte, sbyte, short, ushort, int, uint, long, or ulong.
         
            An enum var is initialized as : "WeekendDays weekEndDats = WeekendDays.Sun;"

             enum WeekendDays below has short as underlying type*/
        enum WeekendDays : short { Sat = 3, Sun };      //Sun is 4

        //functions can take and return instances of enum types !
        static void enumDemo(WeekendDays weekEndDays)
        {
            Console.WriteLine("\n**** enumDemo() ***");

            //ToString() method of enum return name of constant
            Console.WriteLine($"value of weekEndDays is {weekEndDays}");
            //Return numerical value represented by named constant
            Console.WriteLine($"numeric value is {(short)(weekEndDays)}");     // cast to underlying to get numeric value
            // Print underlying storage for the enum.
            Console.WriteLine("WeekendDays uses a {0} for storage", Enum.GetUnderlyingType(weekEndDays.GetType()));

            // Get all name/value pairs for incoming parameter.
            Array enumData = Enum.GetValues(weekEndDays.GetType());

            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}", enumData.GetValue(i));
            }
        }

        //structs shall be used as a light weight version of a class and for objects which don't need inheritance
        //All data fields of struct need to be initialized before they can be used (to call member methods) !
        struct Point
        {
            // Fields of the structure.
            private int X;
            private int Y;

            //structs cannot contain a constructor with no parameters, however an implicit constructor is provided which will initialize
            //all data fields to default values

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            // Add 1 to the (X, Y) position.
            public void Increment()
            {
                X++; Y++;
            }

            // Subtract 1 from the (X, Y) position.
            public void Decrement()
            {
                X--; Y--;
            }

            // Display the current position.
            public void Display()
            {
                Console.WriteLine("X = {0}, Y = {1}", X, Y);
            }
        }

        static void structDemo()
        {
            Console.WriteLine("\n*** structDemo() ***\n");
            //All data fields of struct need to be initialized before they can be used (to call member methods) !

            Point p = new Point();
            p.Display();

            Point p1 = new Point(2, 4);
            p1.Display();
        }  
    }
}
