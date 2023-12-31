﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public static class BinarySearcher
    {
        public static int Search(int[] inputArray,int target)
        {
            //input sanity check
            if (!BinarySearcher.ParallelIsSortedArray(inputArray)) throw new ArgumentException("BinarySearcher.Search only works with sorted array.");
            if (inputArray.Length==0) throw new ArgumentException("input array is empty.");
            //target out of range of the sorted array, return -1
            if (inputArray[0] > target || inputArray[^1] < target) return -1;
            
            //initialize starting,mid and end point index
            int startingPointIndex = 0;
            int endPointIndex = inputArray.Length-1;
            int midPointIndex = (endPointIndex-startingPointIndex)/2;

            //if the target falls on either the start or the end, we found the target
            if (inputArray[startingPointIndex] == target) { return startingPointIndex; }
            if (inputArray[endPointIndex] == target) { return endPointIndex; }
            //initialize default result to -1(not found)
            int result = -1;

            while (!(midPointIndex==startingPointIndex || midPointIndex == endPointIndex)) {
                if (inputArray[midPointIndex] == target) { return midPointIndex;} //midpoint changes for every loop, test if that lands on the target
                if (inputArray[midPointIndex] > target) // go left
                {
                    endPointIndex = midPointIndex;//bring endpoint to the midpoint position
                    midPointIndex = midPointIndex - (midPointIndex - startingPointIndex) / 2; //calculate the new midpoint
                }
                else
                {
                    startingPointIndex = midPointIndex; // go right
                    midPointIndex = midPointIndex + (endPointIndex - startingPointIndex) / 2; //calculate the new midpoint
                }

            }
         
            return result;

        }

        private static bool IsSortedArray(int[] a)
        { //copied from https://stackoverflow.com/questions/11989071/fastest-way-to-check-if-an-array-is-sorted
            int j = a.Length - 1;
            if (j < 1) return true;
            int ai = a[0], i = 1;
            while (i <= j && ai <= (ai = a[i])) i++;
            return i > j;
        }

        private static bool ParallelIsSortedArray(int[] a) //victor's IsSortedArray using Parallel.For, because I can't understand the code copied from SO
        {
            bool isSortedArray = true;
            CancellationTokenSource cts = new();
            var options = new ParallelOptions {
                CancellationToken = cts.Token,
                MaxDegreeOfParallelism = int.Parse(Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS")??"2") };
            try
            {
                Parallel.For(0, a.Length, options,
                (i) =>
                {
                    if (i != a.Length - 1)
                    {
                        if (a[i] > a[i + 1]) { cts.Cancel(); isSortedArray = false; }
                    }
                }
                );
            }
            catch (OperationCanceledException e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                cts.Dispose();
            }
            return isSortedArray;
        }
    }
}
