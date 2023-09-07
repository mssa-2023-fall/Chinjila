using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class MSSASorts
    {
        public IEnumerable<int[]> ArrayData()
        {
            yield return  ( GenerateRandomNumber(200) );
            yield return  ( GenerateRandomNumber(2000) );
            yield return  ( GenerateRandomNumber(20000) );

        }
        [ArgumentsSource(nameof(ArrayData))]
        [Benchmark]
        public void AlexSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (arr[i - 1] > arr[i])
                    {
                        // Swap arr[i-1] and arr[i]
                        (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
                        swapped = true;
                    }
                }
            } while (swapped);
        }
  
        public  void EricSort(int[] nums)
        {
            bool swaps = false;
            do
            {
                swaps = false;
                for (int i = 1; i < nums.Length; i++)

                {
                    if (nums[i - 1] > nums[i])

                    {
                        int temp = nums[i - 1];
                        nums[i - 1] = nums[i];
                        nums[i] = temp;
                        swaps = true;
                    }
                }
            } while (swaps);


            foreach (int item in nums)
            {
                Console.Write(" " + item);
            }
        }
   
        public  void XHSort(int[] ourAry)
        {

            bool doneSwapping = false;

            while (!doneSwapping)
            {
                doneSwapping = true;

                for (int i = 1; i < ourAry.Length; i++)
                {
                    if (ourAry[i] < ourAry[i - 1])
                    {
                        (ourAry[i], ourAry[i - 1]) = (ourAry[i - 1], ourAry[i]); // so leet
                        doneSwapping = false;
                    }
                }
            }


            Console.WriteLine(String.Join(",", ourAry));
        }

   
        public  void GeoffSort(int[] numArr)
        {

            Console.WriteLine(string.Join(",", BubbleSort(numArr)));


            static int[] BubbleSort(int[] numArr)
            {
                for (int i = numArr.Length - 1; i > 0; i--)
                {
                    for (int a = 0; a < numArr.Length - 1; a++)
                    {
                        //swap
                        if (numArr[a] > numArr[a + 1])
                        {
                            (numArr[a], numArr[a + 1]) = (numArr[a + 1], numArr[a]);
                        }
                    }
                }
                return numArr;
            }
        }
  
        public  void ChrisSort(int[] unsortedArray)
        {
            bool sorted;
            for (int i = 0; i < unsortedArray.Length - 1; i++)
            {
                sorted = false;
                for (int j = 0; j < unsortedArray.Length - i - 1; j++)
                {
                    if (unsortedArray[j] > unsortedArray[j + 1])
                    {
                        (unsortedArray[j], unsortedArray[j + 1]) = (unsortedArray[j + 1], unsortedArray[j]);
                        sorted = true;
                    }
                }
                if (sorted == false) break;
            }
        }
    
        public int[] BradleyBubbleSort(int[] numArray)
        {
            var n = numArray.Length;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - 1; j++)
                    if (numArray[j] > numArray[i])
                    {
                        int temp = numArray[j];
                        numArray[j] = numArray[i];
                        numArray[i] = temp;

                    }
            return numArray;
        }
    
        public void LarrySort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 0; i < n - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        // leet tuple
                        (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    
    static int[] GenerateRandomNumber(int size)
        {
            var array = new int[size];
            var rand = new Random();
            var maxNum = 10000;

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(maxNum + 1);

            return array;
        }
    }


}
