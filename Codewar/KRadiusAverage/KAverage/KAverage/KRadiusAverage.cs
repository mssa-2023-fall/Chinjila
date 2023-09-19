using System.Linq;
namespace KAverage
{
    [TestClass]
    public class KRadiusAverage
    {
        [TestMethod]
        public void TestKAverage()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            Assert.AreEqual(5, KAverage(input, 4, 2));
            Assert.AreEqual(KAverage2(input, 4, 2), KAverage(input, 4, 2));
            Assert.AreEqual(-1, KAverage(input, 11, 5));
            Assert.AreEqual(-1, KAverage(input, 2, 4));

        }

        public int KAverage(int[] input, int i ,int k)
        {
            if ((i+k > input.Length-1) || (i-k<0)) { return -1; };
            return (int)Math.Floor(input[(i - k)..(i + k +1)].Average());

        }
        public int KAverage2(int[] input, int i, int k)=>
            ((i + k > input.Length - 1) || (i - k < 0)) ? -1 : (int)Math.Floor(input[(i - k)..(i + k+1)].Average());

       
    }
}