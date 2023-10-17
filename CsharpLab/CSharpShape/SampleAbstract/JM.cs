using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract
{
  
}

namespace SampleAbstract
{
    internal class JM : Shape
    {
        private int _sideLength;
        internal JM()
        {
            //Default Constructor
        }
        internal override int Sides => 5;
        internal override string Name => "Pentagon";
        internal override float GetArea()
        {
            //Calculate Area = (1/4) * sqrt(5(5+2sqrt(5))) * a^2
            return (float)((1.0 / 4.0) * Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5))) * Math.Pow(_sideLength, 2));
        }
        internal override float GetPerimeter()
        {
            // Perimeter = 5 * side length
            return 5 * _sideLength;
        }

        internal override Shape CreateShape(Line oneLine)
        {
            this._sideLength = oneLine.Length;
            return this;
        }
    }
}
