using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract
{
    internal class MA : Shape
    {
        private int _lenghtofSide;  
        internal override string Name => "Triangle";
        internal override int Sides => 3;
       
        internal override Shape CreateShape(Line oneLine)
        {
        this._lenghtofSide = oneLine.Length;
        return this;
        }

        internal override float GetArea()
        {
            return (float)((_lenghtofSide * 3)/2);
        }

        internal override float GetPerimeter()
        {
            return (float)(_lenghtofSide + _lenghtofSide + _lenghtofSide);
        } 
    }
}
