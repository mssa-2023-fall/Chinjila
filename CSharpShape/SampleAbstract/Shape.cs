using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract
{
    internal abstract  class Shape
    {
        internal abstract  int Sides { get; }
        internal abstract string Name { get; }
        internal abstract float GetArea();
        internal abstract float GetPerimeter();
        //internal abstract Shape CreateShape(Point[] points);
        internal abstract Shape CreateShape(Line oneLine);

    }

    internal class Line
    {
        internal int Length;
    }
}
