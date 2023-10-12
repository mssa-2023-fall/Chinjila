using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAbstract
{
    internal class AG : Shape
    {

        internal override int Sides => 3;
        internal override string Name => "Triangle";
        internal float SideB { get; set; }
        internal float SideC { get; set; }
        internal float SideA { get; set; }


        public AG(float sideA, float sideB, float sideC) 
        {
            
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        internal override Shape CreateShape(Line line)
        {
            this.SideB = line.Length;
            this.SideA = line.Length;
            this.SideC = line.Length;
            return this;
        }
        public AG()
        {
            
        }
        internal override float GetArea()
        {
            // Using Heron's formula to calculate the area
            float s = GetPerimeter() / 2 ;
            var area = Math.Sqrt(s * (s -SideA) * (s -SideB) * (s -SideC));
            return (float)area;
        }
        internal override float GetPerimeter()
        {
            return SideC + SideA + SideB;
        }

        //internal float GetDegreeTangent(float opposite, float adjacent)
        //{

        //}




    }
}
