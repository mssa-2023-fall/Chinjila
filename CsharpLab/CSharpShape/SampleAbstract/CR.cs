using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract
{
    internal class CRSquare : Shape
    {
        string shapeName = "Square";
        int sideLength = 6;

        internal override int Sides => 4;

        internal override string Name => shapeName;

        internal override Shape CreateShape(Line oneLine)
        {
            this.sideLength = oneLine.Length;
            return this;
        }

        internal override float GetArea()
        {
            double area = Math.Pow(sideLength, 2);
            return (int)area;
        }

        internal override float GetPerimeter()
        {
            return sideLength * 4;
        }
    }

    internal class CRRectangle : Shape
    {
        string shapeName = "Rectangle";
        int sideLength = 6;
        int sideTwoLength = 6;
        int heightLength = 3;
        int heightTwoLength = 3;

        internal override int Sides => 4;

        internal override string Name => shapeName;

        internal override Shape CreateShape(Line oneLine)
        {
            this.sideLength = oneLine.Length;
            this.sideTwoLength = oneLine.Length;
            this.heightLength = oneLine.Length;
            this.heightTwoLength = oneLine.Length;
            return this;
        }

        internal override float GetArea()
        {
            double area = sideLength * heightLength;
            return (int)area;
        }

        internal override float GetPerimeter()
        {
            return (sideLength * 2) + (heightLength * 2);
        }
    }

    internal class CR : Shape
    {
        string shapeName = "Triangle";
        int sideOne = 5;
        int sideTwo = 6;
        int sideThree = 7;

        internal override int Sides => 3;

        internal override string Name => shapeName;

        internal override Shape CreateShape(Line oneLine)
        {
            this.sideOne = oneLine.Length;
            this.sideTwo = oneLine.Length;
            this.sideThree = oneLine.Length;
            return this;
        }

        internal override float GetArea()
        {
            double s = (sideOne + sideTwo + sideThree) /2; //semi-perimeter
            double area = Math.Sqrt(s*(s-sideOne) * (s-sideTwo) * (s-sideThree));
            return (float)area;
        }

        internal override float GetPerimeter()
        {
            return sideOne + sideTwo + sideThree;
        }
    }
}
