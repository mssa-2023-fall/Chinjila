using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp30
{
    internal class Program
    {
        static int[] originalArrary = new int[]{ 85, 22, 63, 91, 24, 45, 23 ,28, 28 };
        public static void Main(String[] args)
        {

            Console.WriteLine($"Original Array:{string.Join(",",originalArrary)}");
            PutTheLargestNumberAtTheEnd(originalArrary);
            Console.WriteLine($"Sorted Array:{string.Join(",",originalArrary)}");
            Console.ReadLine();
        }

        private static void PutTheLargestNumberAtTheEnd(int[] paramArray)
        {
            int max = 0;
            int indexOfMax = 0;
            for (int i = 0; i < paramArray.Length; i++)
            {
                int item = paramArray[i];
                //compare to next item. if new item > max, reassign max
                if (item > max)
                {
                    max = item;
                    indexOfMax = i;
                }
            }
            if (paramArray.Length > 0)
            {
                paramArray[indexOfMax] = originalArrary[paramArray.Length - 1]; // preserve the last item in paramArray
                originalArrary[paramArray.Length-1] = max;//store the max value to the correct position
                PutTheLargestNumberAtTheEnd(paramArray[0..^1]);
            }
        }
    }
}
