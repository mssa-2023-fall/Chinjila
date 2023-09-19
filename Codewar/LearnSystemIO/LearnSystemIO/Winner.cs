using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSystemIO
{
    public class Winner
    {
        public int Index { get; set; }
        public int Year { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Movie { get; set; }

        public Winner(string input) {
            //parse the input string like:
            // 1, 1928, 44, "Emil Jannings", "The Last Command, The Way of All Flesh"
            //read from 0 to first occurance of ",", do an int.Parse to fill in Index
            //Index = new String(input[0..input.IndexOf(',')]);

            int firstCommaIndex = input.IndexOf(',');
            Index = int.Parse(input.Substring(0, firstCommaIndex));
            int secondCommaIndex = input.IndexOf(',', firstCommaIndex+1);
            Year = int.Parse(input.Substring(firstCommaIndex+1, secondCommaIndex-firstCommaIndex-1));
            int thirdCommaIndex = input.IndexOf(',', secondCommaIndex + 1);
            Age = int.Parse(input.Substring(secondCommaIndex + 1, thirdCommaIndex - secondCommaIndex - 1));
            
            int firstDoubleQuoteIndex = input.IndexOf('"', thirdCommaIndex + 1);
            int secondDoubleQuoteIndex = input.IndexOf('"', firstDoubleQuoteIndex + 1);

            Name = input.Substring(firstDoubleQuoteIndex + 1, secondDoubleQuoteIndex - firstDoubleQuoteIndex - 1);

            int thirdDoubleQuoteIndex = input.IndexOf('"', secondDoubleQuoteIndex + 1);
            int forthDoubleQuoteIndex = input.IndexOf('"', thirdDoubleQuoteIndex + 1);

            Movie = input.Substring(thirdDoubleQuoteIndex + 1, forthDoubleQuoteIndex - thirdDoubleQuoteIndex - 1);
        }
        public Winner()
        {
            
        }
    }
}
