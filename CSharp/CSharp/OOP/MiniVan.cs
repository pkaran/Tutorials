using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    //class MiniVan extends class Car, C# demands that a given class have exactly one direct base class
    //sealed classes cannot be extended 
    sealed class MiniVan : Car
    {
        public int MiniVanArea { get; set; }

        //the default constructor of a base class is called automatically before the logic of the derived constructor is executed
        public MiniVan() { }

        // As a general rule, all subclasses should explicitly call an appropriate base class constructor using the following syntax
        public MiniVan(int vanArea, int year, String make)
            :base(year, make)       // call base class constructor
        {
            MiniVanArea = vanArea;
        }

        /*Topix : Nested Type
        
        In C# (as well as other .NET languages), it is possible to define a type (enum, class,
        interface, struct, or delegate) directly within the scope of a class or structure. When you have done so, the
        nested (or “inner”) type is considered a member of the nesting (or “outer”) class and in the eyes of the
        runtime can be manipulated like any other member (fields, properties, methods, and events).
        
         •	 Nested types allow you to gain complete control over the access level of the inner
        type because they may be declared privately (recall that non-nested classes cannot
        be declared using the private keyword).

        •	 Because a nested type is a member of the containing class, it can access private
        members of the containing class.

        •	 Often, a nested type is useful only as a helper for the outer class and is not intended
        for use by the outside world.*/

        // A public nested type can be used by anybody.
        public class PublicInnerClass { }
        // A private nested type can only be used by members
        // of the containing class.
        private class PrivateInnerClass { }
    }
}
