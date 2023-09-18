
namespace DropWhileTest
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            var test = new int[] { 2, 4, 6, 8, 1, 2, 5, 4, 3, 2 };
            Func<int, bool> isEven = (value) => value % 2 == 0;

            var result = GeofDropWhile(test, isEven);
            Assert.IsTrue(result.Length == 6);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(5, result[2]);

        }
        [TestMethod]
        public void TestMethod2()
        {
            var test = new int[] { 1, 1, 1, 1 };
            Func<int, bool> isEven = (value) => value % 2 == 0;

            var result = GeofDropWhile(test, isEven);
            Assert.IsTrue(result.Length == 4);


        }
        [TestMethod]
        public void TestMethod3()
        {
            var test = new int[] { 2, 2, 2, 2 };
            Func<int, bool> isEven = (value) => value % 2 == 0;

            var result = GeofDropWhile(test, isEven);
            Assert.IsTrue(result.Length == 0);


        }
        [TestMethod]
        public void TestMethod4()
        {
            var test = new int[] { 2, 1, 2, 3, 4 };
            Func<int, bool> isEven = (value) => value % 2 == 0;

            var result = GeofDropWhile(test, isEven);
            Assert.IsTrue(result.Length == 4);

        }
        [TestMethod]
        public void TestMethod5()
        {
            var test = new int[] { };
            Func<int, bool> isEven = (value) => value % 2 == 0;

            var result = GeofDropWhile(test, isEven);
            Assert.IsTrue(result.Length == 0);

        }
        [TestMethod]
        public void TestMethod6()
        {
            var test = new int[] { 2, 1, 2, 3, 4 };
            Func<int, bool> isEven = (value) => value % 2 == 0;

            var result = test.DropWhile(isEven).ToArray();
            Assert.IsTrue(result.Length == 4);

        }

        public static int[] DropWhile(int[] arr, Func<int, bool> pred)
        {
            if (arr.Length == 0) return new int[0];
            int index = 0;
            while (pred(arr[index]))
            {
                index++;
                if (index == arr.Length) { return new int[0]; }
            }
            return arr[index..];
        }

        public static int[] GeofDropWhile(int[] arr, Func<int, bool> pred)
        { // {2,4,6,8,1,2,4,3,5,7}
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (!pred(arr[i])) return arr[i..];
            }
            return new int[0];
        }
    }
    public static class Util {
        public static T[] DropWhile<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            List<T> list = new List<T>();
            bool dropping = true;



            foreach (var a in sequence)
            {
                if (dropping && predicate(a) == true)
                {
                    continue;
                }
                else
                {
                    dropping = false;
                }
                list.Add(a);
            }
            return list.ToArray();
        }

    }
}

   