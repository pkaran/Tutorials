using System;

namespace CSharp.Interface.Common_Interfaces_Implementation
{
    /*This interface allows an object to specify its relationship between other like objects
    
    public interface IComparable
    {
        int CompareTo(object o);
    }
    */

    class Comparable
    {
        public static void demo()
        {
            Employee[] e = { new Employee(1, "asa"), new Employee(-1, "ASA"), new Employee(50, "zada"), new Employee(0, "baba"), new Employee(23, "tat") };

            foreach (Employee emp in e) Console.WriteLine(emp.Rank);

            Array.Sort(e);   // if IComparable interface is not implemented by Employee, you would get a runtime exception

            Console.WriteLine("\nAfter sorting based on Rank:");
            foreach (Employee emp in e) Console.WriteLine(emp.Rank + "  " + emp.Name);

            Array.Sort(e, new EmpNameCompare());

            Console.WriteLine("\nAfter sorting based on Name:");
            foreach (Employee emp in e) Console.WriteLine(emp.Rank + "  " + emp.Name);
        }
    }

    class Employee :IComparable
    {
        public int Rank { get; }
        public string Name { get; }

        public Employee(int rank, string name)
        {
            this.Rank = rank;
            this.Name = name;
        }

       /* Return Value Description : 
        
        Any number less than zero - This instance comes before the specified object in the sort order.
        Zero - This instance is equal to the specified object.
        Any number greater than zero - This instance comes after the specified object in the sort order.
        */

        public int CompareTo(Object o)      // comparison based on Rank
        {
            Employee e = o as Employee;

            if(e == null)
            {
                throw new ArgumentException("An argument of type Employee needs to be passed !");
            }

            if (this.Rank > e.Rank)
            {
                return 1;
            }
            else if (this.Rank < e.Rank)
            {
                return -1;
            }
            else
            {
                return 0;
            }

            //can also do the following:
            //return this.Rank.CompareTo(e.Rank);
        }

        //The object user code can now sort by Name using a strongly associated property, rather than just “having to know” to use the stand-alone EmpNameCompare class type
        // the property below is for user convenience 
        public static System.Collections.IComparer CompareByName
        {
            get
            {
                return (System.Collections.IComparer) new  EmpNameCompare();
            }
        }
    }

    /*A general way to compare two objects.

    interface IComparer
    {
        int Compare(object o1, object o2);
    }
    */

    class EmpNameCompare : System.Collections.IComparer
    {
        public int Compare(object o1, object o2)
        {
            Employee e1 = o1 as Employee;
            Employee e2 = o2 as Employee;

            if(e1 == null || e2 == null)
            {
                throw new ArgumentException("Expected an Employee object as argument");
            }

            return e1.Name.CompareTo(e2.Name);
        }
    }
}
