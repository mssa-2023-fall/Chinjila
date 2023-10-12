using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract
{
    internal class GS : Shape
    {
        private int _lengthOfSide;
        internal override int Sides => 4;
        internal override string Name => "Square";
        
        internal override Shape CreateShape(Line oneLine)
        {
            this._lengthOfSide = oneLine.Length;
            return this;
        }
        internal override float GetPerimeter()
        {
            return this._lengthOfSide * Sides;
        }
        internal override float GetArea()
        {
            return this._lengthOfSide * this._lengthOfSide;
        }
    }
}
