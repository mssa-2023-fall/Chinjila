using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public static class BinarySearcher
    {
        public static int Search(int[] inputArray,int target)
        {

            if (inputArray[0] > target || inputArray[^1] < target) return -1;
            int startingPointIndex = 0;
            int endPointIndex = inputArray.Length-1;
            int midPointIndex = (endPointIndex-startingPointIndex)/2;

            int result = -1;
            while (!(midPointIndex==startingPointIndex || midPointIndex == endPointIndex)) {
                if (inputArray[midPointIndex] == target) { return midPointIndex;}
                if (inputArray[startingPointIndex] == target) { return startingPointIndex; }
                if (inputArray[endPointIndex] == target) { return endPointIndex; }

                
                if (inputArray[midPointIndex] > target) // go left
                {
                    endPointIndex = midPointIndex;
                    midPointIndex = midPointIndex - (midPointIndex - startingPointIndex) / 2;
                }
                else
                {
                    startingPointIndex = midPointIndex; // go right
                    midPointIndex = midPointIndex + (endPointIndex - startingPointIndex) / 2;
                }

            }
         
            return result;

        }
    }
}
