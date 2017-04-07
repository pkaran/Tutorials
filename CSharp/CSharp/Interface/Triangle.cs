using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Interface
{
    // a class can extend one class and any number of interfaces
    class Triangle : Point
    {
        int numOfPoints = 3;

        //even though the property defined in interface only has set, having both set and get works as well !
        public int NumOfPoints
        {
            set
            {
                numOfPoints = value;
            }
            get
            {
                return numOfPoints;
            }
        }

        //Given that interfaces are valid .NET types, you may construct methods that take interfaces as parameters
        //check if object to be passed actually implements the Point class using the as and is keyword (look in method OOP)
        public void setOtherShapePoint(Point p)
        {
            p.NumOfPoints = this.NumOfPoints;
        }

        //Interfaces can also be used as method return values
        public Point returnPointType()
        {
            Triangle t = new Triangle();

            // will return null if t does not implement point otherwise will implicitly cast to Point and return
            return t as Point;
        }
    }
}
