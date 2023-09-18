using MergeSortPart;

namespace MergeSortTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MergeSortTest()
        {
       

        }
        [TestMethod]
        public void MergeTest()
        {
            int[] arr1 = { 5 };
            int[] arr2 = { 3 };

            var result = MergeSort.mergeArrays(arr1, arr2);

            Assert.AreEqual(result[0], 3);
            Assert.AreEqual(result[1], 5);
    

        }
        [TestMethod]
        public void DivideTest()
        {
            int[] testInput = RandoItemo();


            var result = MergeSort.Divide(testInput,0,testInput.Length-1);
            Array.Sort(testInput);
            CollectionAssert.AreEqual(testInput, result);

        }
        //I need a method that can give 100 random item int array
        public int[] RandoItemo()
        {
            Random rand = new Random();
            int[] randoArr = new int[100];
            for (int i = 0; i <  100; i++) 
            {
                randoArr[i] = rand.Next(1,99);
            }
            return randoArr;
        }
    }
}