using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract
{
    internal class VC: Shape
    {
        private int _lengthOfSide;
        internal override  string Name => "Hexagon";
        internal override int Sides => 6;
        internal override Shape CreateShape(Line oneLine)
        {
          
           this._lengthOfSide = oneLine.Length;
           return this;
        }
        internal override float GetArea()
        {
            //Area of hexagon = (3√3 s2)/ 2
            return (float)(3 * Math.Sqrt(3) * Math.Pow(_lengthOfSide, 2)) / 2;
        }

        internal override float GetPerimeter()
        {
            return Sides* this._lengthOfSide;
        }
        public VC()
        {
            
        }
    }
}
