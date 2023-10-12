using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract
{
    internal class LN : Shape
    {
        internal override string Name => "Shape";

        internal override int Sides => 4;

        public float diagonal1 { get; set; }
        public float diagonal2 { get; set; }


        internal override float GetArea()
        {
            return this.diagonal1 * this.diagonal2 / 2;
        }
        internal float GetSideLength()
        {
            return (float)Math.Sqrt((diagonal1 * diagonal1 + diagonal2 * diagonal2) / 4);


        }
        internal override float GetPerimeter()
        {
            float somePerimeter = 4 * GetSideLength();
            return somePerimeter;
        }
        internal override Shape CreateShape(Line oneLine)
        {
            var someLength = new LN();
            someLength.diagonal1 = oneLine.Length;
            return someLength;
            
        }
        public LN()
        {
            this.GetSideLength();
            StringBuilder howThisLooks = new StringBuilder();
            howThisLooks.AppendLine("   --------------------------");
            howThisLooks.AppendLine("  /                        /");
            howThisLooks.AppendLine(" /                        /");
            howThisLooks.AppendLine("/                        /");
            howThisLooks.AppendLine("-------------------------");
        }

    }
}



/*
 *         internal abstract int Sides { get; }
        internal abstract int Name { get; }
        internal abstract float GetArea();
        internal abstract float GetPerimeter();
        internal abstract Shape CreateShape(Line oneLine);

        internal abstract Shape CreateShape(Point[] points);
*/