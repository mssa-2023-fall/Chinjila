using SampleAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract
{
    internal class BM : Shape
    {
        internal override int Sides => 5;
        
        internal override string Name => "Pentagon";

        public float side;


        internal override float GetArea()
        {
            float area = (float)((5 / 4) * Math.Pow(side, 2) * Math.Tan((3 * Math.PI) / 10));
            //area = (5/4) · sides^2 · tan(3π/10)
            return area;
        }

        internal override float GetPerimeter()
        {
            float perimiter = (5 * side);
            return perimiter;
        }

        internal override Shape CreateShape(Line oneLine)
        {
            this.side = oneLine.Length;
            return this;
        }
    }
}


//internal abstract int Sides { get; }
//internal abstract int Name { get; }
//internal abstract float GetArea();
//internal abstract float GetPerimeter();
//internal abstract Shape CreateShape(Point[] points);
