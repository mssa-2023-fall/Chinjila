using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract
{
    internal class EM : Shape
    {
        private int _sideLength;
        internal override string Name => "Octagon";

        internal override int Sides => 8;

        public EM(int sideLenth) 
        {
            _sideLength = sideLenth;
        }

        public EM()
        {
            _sideLength = 4;
        }

        internal override Shape CreateShape(Line oneLine)
        {
            Console.WriteLine("What's the opposite of Octagon?");
            Console.WriteLine("Octahere");
            return new EM(oneLine.Length);
        }

        internal override float GetArea()
        {
            return (float)(2 * (1 + Math.Sqrt(2)) * Math.Pow(_sideLength, 2));
        }

        internal override float GetPerimeter()
        {
            return _sideLength * Sides;
        }
    }
}
