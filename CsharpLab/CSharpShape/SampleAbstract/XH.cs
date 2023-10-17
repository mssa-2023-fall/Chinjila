using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract {
    internal class XH : Shape {

        // ========== ATTRIBUTES ==========
        private int _lengthOfSide;
        internal override string Name => "Triangle";
        internal override int Sides => 3;

        // ========== METHODS ==========
        internal override Shape CreateShape(Line oneLine) {
           this._lengthOfSide = oneLine.Length;
           return this;
        }

        internal override float GetArea() {
            // Area of triangle b * h * .5 
            // h = a × √3 / 2, where a is a side of the triangle.
            return (float)(_lengthOfSide * (_lengthOfSide * Math.Sqrt(3) / 2) * .5);
        }

        internal override float GetPerimeter() {
            return Sides * this._lengthOfSide;
        }

        public XH() {
            _lengthOfSide = 5;
        }
    }
}
