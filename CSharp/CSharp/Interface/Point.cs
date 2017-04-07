using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Interface
{
    /*interface is a set of public and abstract members
     * 
     * interfaces never specify a base class (not even System.Object; however, as you will see later in this chapter, an
    interface can specify base interfaces). 
    
    interface types cannot be implemneted ! an interface can extend as many classes as it wants
    Point p = new Point();   // this is an error !

    interface can implemented by class and structs

    the members of an interface never specify an access modifier (as all interface members are implicitly public and abstract)*/
    interface Point
    {
        // definitions for get and set cannot be provided , properties in interface cannot be initialized
        int NumOfPoints { set; }        // this is a property prototype

        // Error! Interfaces cannot have data fields!
        // public int numbOfPoints;

        // Error! Interfaces do not have constructors!
        //public IPointy() { numbOfPoints = 0; }

        // Error! Interfaces don't provide an implementation of members!
        //byte GetNumberOfPoints() { return numbOfPoints; }
    }
}