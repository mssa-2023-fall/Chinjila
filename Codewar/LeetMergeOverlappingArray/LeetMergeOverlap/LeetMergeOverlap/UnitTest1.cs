using System.Net.Security;

namespace LeetMergeOverlap
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[][] test = new int[4][];
            test[0]=  new int[] { 1, 3};
            test[1] = new int[] { 2, 6 };
            test[2] = new int[] { 8, 10 };
            test[3] = new int[] { 15, 18 };
            int[][] result = Merge(test);
        }
        //[[1,4],[0,2],[3,5]]
        [TestMethod]
        public void TestMethod2()
        {
            int[][] test = new int[3][];
            test[0] = new int[] { 1, 4 };
            test[1] = new int[] { 0, 2 };
            test[2] = new int[] { 3, 5 };
            int[][] result = Merge(test);
            Console.WriteLine(result);
        }

        //[[1,3],[2,6],[8,10],[15,18]]

        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (x, y) => x[0] - y[0]);

            List<int[]> result = new List<int[]>();
        for (int i = 0; i<intervals.GetLength(0);i++) {
                
                if ((i+1)>= intervals.GetLength(0)) {
                    result.Add(intervals[i]);
                    continue;
                }

                if (intervals[i + 1][0] <= intervals[i][1])
                {
                    int[] merged = mergeTwoPart(intervals[i], intervals[i + 1]);
                    result.Add(merged);
                    i++;
                }
                else
                {
                    result.Add(intervals[i]);
                }
        }
            int[][] result2=new int[result.Count][];
            result.CopyTo(result2);
            if (Enumerable.SequenceEqual(intervals, result2))
            {
                return result2;
            }
            else {
                result2 = Merge(result2);
            }
            return result2;
        }

        private int[] mergeTwoPart(int[] ints1, int[] ints2)
        {
            return new int[] { ints1.Concat(ints2).Min(), ints1.Concat(ints2).Max() };
        }
    }
}