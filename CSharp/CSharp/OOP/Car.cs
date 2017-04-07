using System;

/* Topic : Importing Static Members via the C# using Keyword

using directive below will import all static members of System.Console class into the declaring code file ( Car.cs)
With these “static imports,” the remainder of your code file is able to directly use the static members of the Console class
without the need to prefix the defining class (although that would still be just fine, provided that you have imported the System namespace)

With using static System.Console; and NOT using System; :
    WriteLine();

With using static System.Console; and using System; : (both are okay)
    WriteLine();
    Console.WriteLine();

    A more realistic example of code simplification might involve a C# class that is making substantial
use of the System.Math class (or some other utility class). Since this class has nothing but static members,
it could be somewhat easier to have a static using statement for this type and then directly call into the
members of the Math class in your code file.
    However, be aware that overuse of static import statements could result in potential confusion. First,
what if multiple classes define a WriteLine() method? The compiler is confused and so are others reading
your code. Second, unless a developer is familiar with the .NET code libraries, he or she might not know that
WriteLine() is a member of the Console class. Unless a person were to notice the set of static imports at the
top of a C# code file, they might be quite unsure where this method is actually defined. */

using static System.Console;

namespace CSharp
{

    //Static class : When a class has been defined as static, it is not creatable using the new keyword, and it can contain 
    //only members or data fields marked with the static keyword.
    class Car
    {

        private int year;
        private String make;

        // const variables must be initialized when decleared ! They cannot be initialized in a constructor !!
        public const double PI = 3.14;  
      

        /*TOPIC : Read only property
         * 
        Closely related to constant data is the notion of read-only field data (which should not be confused with
        a read-only property). Like a constant, a read-only field cannot be changed after the initial assignment.
        However, unlike a constant, the value assigned to a read-only field can be determined at runtime and,
        therefore, can legally be assigned within the scope of a constructor but nowhere else.*/
        public static readonly double ReadOnlyStaticPI; // static read only property can only be assigned a value in a static constructor or via variable initialization
        public readonly double ReadOnlyPI;  // read only property can only be assigned a value in a constructor or via variable initialization

        /* TOPIC : Constructors
         
         A constructor is a special method of a class that is called indirectly when creating an object using the new keyword. 
         Constructors never have a return value (not even void) and are always named identically to the class they are constructing.

        Every C# class is provided with a “freebie” default constructor that you can redefine if need be. By definition,
        a default constructor never takes arguments. After allocating the new object into memory, the default constructor 
        ensures that all field data of the class is set to an appropriate default value

        You can prevent a class from being instantiated by making the constructor private:
        private Car() {}

        as soon as you define a custom constructor with any number of parameters, the default constructor is silently removed 
        from the class and is no longer available. when you define a unique constructor, the compiler assumes you have taken matters
        into your own hands. Therefore, if you want to allow the object user to create an instance of your type with the default
        constructor, as well as your custom constructor, you must explicitly redefine the default

        if all data fields of class are not initialized by a constructor, then uninitialized data fields will automatically be set to their default values
         */
        public Car() { Console.WriteLine("*** From Car() ***"); }

        /* TOPIC : Constructor chaining
        
        once a constructor passes arguments to the designated master constructor (and that constructor has processed the data), 
        the constructor invoked originally by the caller will finish executing any remaining code statements */
        public Car(String make)    // this keyword can be used for constructor chaining
            : this(1950, make) { Console.WriteLine("This statement is printed AFTER call from constructor called by this is returned"); }      

        /* TOPIC : Using optional arguments in place of constructor chaining

        Let us have a master constructor with following header : public Motorcycle(int intensity = 0, string name = "")
        We can use optional arguments and named arguments thus avoiding need of constructor chaining as follows:

            // driverName = "", driverIntensity = 0
            Motorcycle m1 = new Motorcycle();

            // driverName = "Tiny", driverIntensity = 0
            Motorcycle m2 = new Motorcycle(name:"Tiny");

            // driverName = "", driverIntensity = 7
            Motorcycle m3 = new Motorcycle(7);
         */

        public Car(int year, String make)
        {
            ReadOnlyPI = 3.14;

            this.year = year;
            make = this.make;

            //objectDescription is a static field whose value is reset each time you create a new object !
            objectDescription = "This object is a Car";
        }

        /*Topic : Static keyword
        
        Static members of a class must be invoked directly from the class level, rather than from an object reference variable.
        Static members are of class level rather than object level
        
        static members are items that are deemed (by the class designer) to be so commonplace
        that there is no need to create an instance of the class before invoking the member. While any class can
        define static members, they are quite commonly found within utility classes. By definition, a utility class is a
        class that does not maintain any object-level state and is not created with the new keyword. Rather, a utility
        class exposes all functionality as class-level (aka static) members
        
         the static keyword can be applied to the following:
            •	 Data of a class
            •	 Methods of a class
            •	 Properties of a class
            •	 A constructor
            •	 The entire class definition
            •	 In conjunction with the C# using keyword
         */

        /*TOPIC : member initialization syntax 
        This approach will ensure the static field is assigned only once (given that it is not assigned else where)
        this can also be used with a non-static data field (use the syntax below to initialize, if not assigned a different value in constructor, 
        then the originaly assigned value will remain intact and NOT be assigned a default value which is the case if not initialized) */
        public static String objectDescription = "This object is a Car";

        public static int objectNumber;

        /*TOPIC : Static Constructor
        
        Here are a few points of interest regarding static constructors:

        •	 A given class may define only a single static constructor. In other words, the static constructor cannot be overloaded.
        •	 A static constructor does not take an access modifier and cannot take any parameters.
        •	 A static constructor executes exactly one time, regardless of how many objects of the type are created.
        •	 The runtime invokes the static constructor when it creates an instance of the class or before accessing the first static 
             member invoked by the caller.
        •	 The static constructor executes before any instance-level constructors */
        static Car()
        {
            ReadOnlyStaticPI = 3.14;      // static read only property can only be assigned a value in a static constructor or via variable initialization
            objectNumber = 12;
        }

        public void displayInfo()
        {
            //static data can be accessed for a non-static method however non-static data cannot be accessed by a static member
            WriteLine("Year of car is {0} and its make is {1}\nObject description : " + objectDescription, year, make);
        }

        public static void setObjectDescription(String description)
        {
            //this.objectDescription = description;     // this cannot be used to refer to static members, use class name instead
            //displayInfo();                            // non-static methods cannot be called from a static method
            Car.objectDescription = description;
        }

        /*TOPIC : Properties
         properties are just a simplification for “real” accessor and mutator methods.

            Read only property : remove the set {} part
            Write only property : remove the get {} part

            static properties are used for a static underlying data type
            To make a porperty static, add the static keyword. Example: public static double InterestRate { get{} set{}}
            From a static property, non-static members cannot be accessed by set {} and get {}
         */

        private int numberOfWheels;

        //public property for numberOfWheels
        public int NumberOfWheels
        {
            get { return numberOfWheels; }

            set
            {
                //Within a set scope of a property, you use a token named value, which is used to represent the incoming
                //value used to assign the property by the caller
                // When the token value is within the set scope of the property, it always represents the
                //value being assigned by the caller, and it will always be the same underlying data type as the property itself

                if (value < 1 || value > 4)
                {
                    Console.WriteLine("Incorrect wheel number !");
                    return;
                }

                numberOfWheels = value;
            }
        }

        //On getting or setting a value for property below, stack overflow exception will be raised ! Need a backing field !!
        public int NumOfPoints
        {
            set
            {
                NumOfPoints = 3;
            }
            get
            {
                return NumOfPoints;
            }
        }

        /* Automatic Property (cannot have custom get and/or get) : 
         When defining automatic properties, you simply specify the access modifier, underlying data type,
         property name, and empty get/set scopes. At compile time, your type will be provided with an autogenerated
         private backing field and a fitting implementation of the get/set logic. 
         
         Automatic properties are assigned default values ! (class related properties are assigned null ! be careful !!)

        if you directly invoke a property with underlying as class object, you will receive a “null reference exception” at runtime, 
        as the class variable used  in the background has not been assigned to a new object. */

        //assign an initial value to the underlying backing field generated by the compiler, not possibe to do this if the property has
        //custom defined get and/or set ! , use construtor instead 
        public int MaxCapacity { get; set; } = 1;    // you may have get and set bodies just like NumberOfWheels property

        // Read-only property? This is OK!
        //assign an initial value to the underlying backing field generated by the compiler
        // a value to a read only propety can also be assigned in the constuctor
        public int MyReadOnlyProp { get; }

        // Auto implemented properties need to have get. 
        //However, properties defined using full definition may only have a set (as shown below)
        //public int MyWriteOnlyProp { set; }

        //NOTE: property below is not automacilly generated like the ones above !
        private int myWriteOnlyProp;
        public int MyWriteOnlyProp
        {
            set
            {
                myWriteOnlyProp = value;
            }
        }

        //Visual Studio tip : type prop and then tab for auto generating and customising a property syntax
    }
}
