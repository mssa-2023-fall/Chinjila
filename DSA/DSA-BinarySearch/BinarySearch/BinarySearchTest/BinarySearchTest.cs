using System.Drawing;
using BinarySearch;
namespace BinarySearchTest
{
    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        public void BinarySearchShouldReturnNegativeOneWhenItemIsAboveMaxorBelowMin()
        {
            int[] sorted = GenerateSortedNumber(200);
            int result = BinarySearcher.Search(sorted, 500);
            Assert.AreEqual(-1, result);
            result = BinarySearcher.Search(sorted, -10);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        [DynamicData(nameof(AllArrayItemValue))]
        public void BinarySearchShouldReturnCorrectIndexPositionUsingSortedArray(int valueToSearch,int expectedIndex)
        {
            int[] sorted = GenerateSortedNumber(200);
            int result = BinarySearcher.Search(sorted, valueToSearch);
            Assert.AreEqual(expectedIndex, result);

        }

        [TestMethod]
        [DataRow(1,0)]
        [DataRow(3, 1)]
        [DataRow(5, 2)]
        [DataRow(7, 3)]
        [DataRow(15, 8)]
        [DataRow(14, 7)]
        [DataRow(13, 6)]
        [DataRow(12, 5)]
        [DataRow(9, 4)]
        [DataRow(6, -1)]
        [DataRow(4, -1)]
        [DataRow(2, -1)]
        [DataRow(0, -1)]
        [DataRow(-1, -1)]
        [DataRow(int.MaxValue, -1)]
        [DataRow(int.MinValue, -1)]
        public void BinarySearchShouldReturnCorrectIndexPositionUsingRandomArray(int valueToSearch, int expectedIndex)
        {
            int[] sorted = { 1, 3, 5, 7, 9, 12, 13, 14, 15 };
            

            int result = BinarySearcher.Search(sorted, valueToSearch);
            Assert.AreEqual(expectedIndex, result);

        }
        [TestMethod]
        public void BinarySearchShouldWorkWith1ElementArray()
        {
            int[] sorted = { 1 };

            int result = BinarySearcher.Search(sorted, 1);
            Assert.AreEqual(0, result);

        }
        [TestMethod]
        public void BinarySearchShouldWorkWith0ElementArray()
        {
            int[] empty = { };

            Assert.ThrowsException<ArgumentException>(() => BinarySearcher.Search(empty, 5));

        }
       
        [TestMethod]
        public void BinarySearchShouldWorkWith256ElementArray()
        {
            int[] sorted = GenerateSortedNumber(256);

            int result = BinarySearcher.Search(sorted, 0);
            Assert.AreEqual(0, result);
            result = BinarySearcher.Search(sorted, 255);
            Assert.AreEqual(255, result);

        }
        [TestMethod]
        public void UnsortedArrayShouldThrowArgumentException()
        {
            int[] unsorted =  { 1, 5, 3, 7, 9, 12, 13, 14, 15 };

            Assert.ThrowsException<ArgumentException>(()=>BinarySearcher.Search(unsorted, 5));

        }

        public static int[] GenerateRandomNumber(int size)
        {
            var array = new int[size];
            var rand = new Random();
            var maxNum = 10000;

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(maxNum + 1);

            Array.Sort(array);
            return array;
        }
        public static int[] GenerateSortedNumber(int size)
        {
            var array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }

        public static IEnumerable<object[]> AllArrayItemValue
        {
            get
            {
                for (int i = 0; i < 200; i++)
                {
                    yield return new object[] { i, i };
                }
            }
        }

    }


}
