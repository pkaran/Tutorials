using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Interface.Common_Interfaces_Implementation
{
    /*
     * 
    IClonable interface looks as follows:

    public interface ICloneable
    {
        object Clone();
    } 

    Implement Clone method to return a deep copy of the current object

    Object MemberwiseClone() method in SYstem.oject returns a shallow copy. Call this function to first get a shallow copy in Clone() and then
    perform deep copy for references in object to be cloned (deep copied)
    */

    class Cloneable
    {
        public static void demo()
        {
            Coordinates c1 = new Coordinates("test1", "test2");

            //need to cast since Clone() returns an object !
            Coordinates c2 = (Coordinates) c1.shallowCopy();

            Console.WriteLine("Shallow Copy:\n\nc1 = {0}", c1);
            Console.WriteLine("c2 = {0}", c2);

            c1.p1.Description = "modified c1.p1.Description";

            Console.WriteLine("\nc1 = {0}", c1);
            Console.WriteLine("c2 = {0}", c2);

            c1 = new Coordinates("test1", "test2");
            c2 = (Coordinates)c1.Clone();

            Console.WriteLine("\nDeep copy\n\nc1 = {0}", c1);
            Console.WriteLine("c2 = {0}", c2);

            c1.p1.Description = "modified c1.p1.Description";

            Console.WriteLine("\nc1 = {0}", c1);
            Console.WriteLine("c2 = {0}", c2);
        }
    }

    class Coordinates : ICloneable
    {
        public P p1, p2;

        public Coordinates(String p1, String p2)
        {
            this.p1 = new P(p1);
            this.p2 = new P(p2);
        }

        /*To summarize the cloning process, if you have a class or structure that contains nothing but value
        types, implement your Clone() method using MemberwiseClone() (see shallowCopy()). However, if you have a custom type
        that maintains other reference types, you might want to create a new object that takes into account each
        reference type member variable in order to get a “deep copy.” */
        public object Clone()          // Return a deep copy of the current object
        {
            Coordinates clone = (Coordinates) MemberwiseClone();       // shallow copy (i.e. reference types still point to original object's data

            // allocate new objects for reference types ! otherwise they will point to objects in object to be deep copied 
            clone.p1 = new P(p1.Description);       
            clone.p2 = new P(p2.Description);

            return clone;
        }

        public object shallowCopy()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return "p1 : " + p1.Description + ", p2 : " + p2.Description;
        }
    }

    class P
    {
        public String Description { get; set; }

        public P(String description)
        {
            Description = description;
        }
    }
}
