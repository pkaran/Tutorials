using System;
using System.Collections;

namespace CSharp.Interface.Common_Interfaces_Implementation
{
    /*
     IEnumerable informs the caller that object's items can be enumerated

     IEnumerator interface provides the infrastructure to allow the caller to traverse the internal objects contained by the 
     IEnumerable-compatible container

     Following are definitions of the two interfaces:

     public interface IEnumerable
     {
        IEnumerator GetEnumerator();
     }

     GetEnumerator() method returns a reference to yet another interface named System.Collections.IEnumerator

    public interface IEnumerator
    {
        bool MoveNext (); // Advance the internal position of the cursor.
        object Current { get;} // Get the current item (read-only property).
        void Reset (); // Reset the cursor before the first member.
    }
     */
    class Enumerable : IEnumerable
    {
        public static void demo()
        {
            Enumerable garage = new Enumerable();

            //The foreach loop completes when the end of the iterator method or a yield break statement is reached.
            foreach (Car c in garage) Console.WriteLine(c);

            IEnumerator i = garage.GetEnumerator();
            i.MoveNext();   // MoveNext() needs to be called at least once to be able to move to first item
            Car myCar = (Car)i.Current;     
            Console.WriteLine("\nCar make is {0}", myCar.Make);

            Console.WriteLine("\nFrom customIterator :");
            foreach (Car c in garage.customIterator(true)) Console.WriteLine(c);
        }

        private Car[] carArray;

        public Enumerable()
        {
            carArray = new Car[] { new Car("Toyota"), new Car("Ford"), new Car("Tesla") };
        }

        //iterator is a member that specifies how a container’s internal items should be returned when processed by foreach
        public IEnumerator GetEnumerator()
        {
            // the following 3 ways all work fine :

            /*yield
            
            When you use the yield keyword in a statement, you indicate that the method, operator, or get accessor in which it 
            appears is an iterator. Using yield to define an iterator removes the need for an explicit extra class (the class 
            that holds the state for an enumeration, see IEnumerator<T> for an example) when you implement the IEnumerable and 
            IEnumerator pattern for a custom collection type.
            
            */

            // #1
            /*
            foreach(Car c in carArray)
            {
                yield return c;  //You use a yield return statement to return each element one at a time.
            }
            */

            // #2

            yield return carArray[0];
            yield return carArray[1];
            yield return carArray[2];
            //yield break;     // you can use a yield break statement to end the iteration, without using it, 
                               // iteration stops when end of method is reached
            

            //#3, Return the array object's IEnumerator.
            //return carArray.GetEnumerator();
        }

        //When building a named iterator, be aware that the method will return the IEnumerable interface, rather than the 
        //expected IEnumerator-compatible type. custom iterators can take in any number of arguments
        public IEnumerable customIterator(bool reverse)
        {
            if (!reverse)
            {
                foreach (Car c in carArray) yield return c;
            }

            else
            {
                for(int i = carArray.Length - 1; i >= 0; i--)
                {
                    yield return carArray[i];
                }
            }
        }
    }

    class Car
    {
        public string Make { get; }

        public Car(string make)
        {
            Make = make;
        }

        public override string ToString()
        {
            return Make;
        }
    }
}
