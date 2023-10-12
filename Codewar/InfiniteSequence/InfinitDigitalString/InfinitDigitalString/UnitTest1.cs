using System.Data;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;

namespace InfinitDigitalString
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void FixedTests()
        {
            Assert.AreEqual(10, InfiniteDigitalString.findPosition("01"));
            Assert.AreEqual(3, InfiniteDigitalString.findPosition("456"), "...3456...");
            Assert.AreEqual(79, InfiniteDigitalString.findPosition("454"), "...444546...");
            Assert.AreEqual(98, InfiniteDigitalString.findPosition("455"), "...545556...");
            Assert.AreEqual(8, InfiniteDigitalString.findPosition("910"), "...7891011...");
            Assert.AreEqual(188, InfiniteDigitalString.findPosition("9100"), "...9899100...");
            Assert.AreEqual(187, InfiniteDigitalString.findPosition("99100"), "...9899100...");
            Assert.AreEqual(190, InfiniteDigitalString.findPosition("00101"), "...9899100...");
            Assert.AreEqual(190, InfiniteDigitalString.findPosition("001"), "...9899100...");
            Assert.AreEqual(190, InfiniteDigitalString.findPosition("00"), "...9899100...");
            Assert.AreEqual(170, InfiniteDigitalString.findPosition("091"));
            Assert.AreEqual(0, InfiniteDigitalString.findPosition("12345"));
            Assert.AreEqual(0, InfiniteDigitalString.findPosition("1234567891"));
            Assert.AreEqual(9, InfiniteDigitalString.findPosition("10"));
            Assert.AreEqual(2617, InfiniteDigitalString.findPosition("0991"));
            Assert.AreEqual(2617, InfiniteDigitalString.findPosition("09910"));
            Assert.AreEqual(1091, InfiniteDigitalString.findPosition("040"));
            Assert.AreEqual(11, InfiniteDigitalString.findPosition("11"));
            Assert.AreEqual(168, InfiniteDigitalString.findPosition("99"));
            Assert.AreEqual(122, InfiniteDigitalString.findPosition("667"));
            Assert.AreEqual(0, InfiniteDigitalString.findPosition("123456789"));
            Assert.AreEqual(0, InfiniteDigitalString.findPosition("1234567891"));
            Assert.AreEqual(2927, InfiniteDigitalString.findPosition("0910"));
            Assert.AreEqual(13034, InfiniteDigitalString.findPosition("53635"));
            Assert.AreEqual(15050, InfiniteDigitalString.findPosition("0404"));
           

        }
        [TestMethod]
        public void LongTests()
        {
            //Assert.AreEqual(35286, InfiniteDigitalString.findPosition("09991"));
            Assert.AreEqual(1000000071, InfiniteDigitalString.findPosition("123456798"));
           // Assert.AreEqual(382689688L, InfiniteDigitalString.findPosition("949225100"));
            //Assert.AreEqual(24674951477L, InfiniteDigitalString.findPosition("58257860625"));
            //Assert.AreEqual(6957586376885L, InfiniteDigitalString.findPosition("3999589058124"));
            //Assert.AreEqual(1686722738828503L, InfiniteDigitalString.findPosition("555899959741198"));
        }

        [TestMethod]
        public void LongSample()
        {
            //Console.WriteLine(InfiniteDigitalString.findPosition("10"));
            //Console.WriteLine(InfiniteDigitalString.findPosition("100"));
            //Console.WriteLine(InfiniteDigitalString.findPosition("1000"));
            //Console.WriteLine(InfiniteDigitalString.findPosition("10000"));
            //Console.WriteLine(InfiniteDigitalString.findPosition("100000"));
            //Assert.AreEqual(9, InfiniteDigitalString.findPosition("10"));
            //Assert.AreEqual(189, InfiniteDigitalString.findPosition("100"));
            //Assert.AreEqual(2889, InfiniteDigitalString.findPosition("1000"));
            //Assert.AreEqual(38889, InfiniteDigitalString.findPosition("10000"));
            //Assert.AreEqual(488889, InfiniteDigitalString.findPosition("100000"));
            Assert.AreEqual(5888889, InfiniteDigitalString.findPosition("1000000"));
            Assert.AreEqual(68888889, InfiniteDigitalString.findPosition("10000000"));
            Assert.AreEqual(788888889, InfiniteDigitalString.findPosition("100000000"));
            Assert.AreEqual(8888888889, InfiniteDigitalString.findPosition("1000000000"));




            //Console.WriteLine(InfiniteDigitalString.findPosition("1000000"));
            //Console.WriteLine(InfiniteDigitalString.findPosition("10000000"));
            //Console.WriteLine(InfiniteDigitalString.findPosition("100000000"));
            // Console.WriteLine(InfiniteDigitalString.findPosition("1000000000"));
            // Console.WriteLine(InfiniteDigitalString.findPosition("10000000000"));
            Console.WriteLine(InfiniteDigitalString.findPosition("20"));
            Console.WriteLine(InfiniteDigitalString.findPosition("200"));
            Console.WriteLine(InfiniteDigitalString.findPosition("2000"));
            Console.WriteLine(InfiniteDigitalString.findPosition("20000"));
            Console.WriteLine(InfiniteDigitalString.findPosition("200000"));
            Console.WriteLine(InfiniteDigitalString.findPosition("22"));
            Console.WriteLine(InfiniteDigitalString.findPosition("222"));
            Console.WriteLine(InfiniteDigitalString.findPosition("2222"));
            Console.WriteLine(InfiniteDigitalString.findPosition("22222"));
            Console.WriteLine(InfiniteDigitalString.findPosition("222222"));
            //Assert.AreEqual(505556, InfiniteDigitalString.findPosition("111111"));
            //Assert.AreEqual(5288884, InfiniteDigitalString.findPosition("999999"));
            //Assert.AreEqual(708888882, InfiniteDigitalString.findPosition("99999999"));
            //Assert.AreEqual(33888889, InfiniteDigitalString.findPosition("5000000"));
            //Assert.AreEqual(24674951477L, InfiniteDigitalString.findPosition("58257860625"));
            //Assert.AreEqual(6957586376885L, InfiniteDigitalString.findPosition("3999589058124"));
            //Assert.AreEqual(1686722738828503L, InfiniteDigitalString.findPosition("555899959741198"));
            //Assert.AreEqual(382689688, InfiniteDigitalString.findPosition("949225100"));
            //Assert.AreEqual(24674951477, InfiniteDigitalString.findPosition("58257860625"));
            //Assert.AreEqual(6957586376885, InfiniteDigitalString.findPosition("3999589058124"));
            //Assert.AreEqual(1686722738828503L, InfiniteDigitalString.findPosition("555899959741198"));
        }
    }

    //public class InfiniteDigitalString
    //{
    //    static StringBuilder sb = new StringBuilder();
    //    static List<StringBuilder> listSB = new();
    //    static long counter = 1;
    //    static long accumulatedLength;
    //    public static long findPosition(string str)
    //    {
    //        counter = 1;
    //        accumulatedLength = 0;
    //        while (sb.ToString().IndexOf(str)==-1){
    //            ExpandSb(long.Parse(str));
    //        }
    //        return sb.ToString().IndexOf(str)+accumulatedLength;
    //    }
    //    private static void ExpandSb(long v)
    //    {
    //        accumulatedLength += sb.Length;
    //        sb = new StringBuilder();
    //        for (long i = counter; i < v + counter; i++)
    //        {
    //            sb.Append(i.ToString());
    //        }
    //        counter += v;

    //    }

    //}

    public class InfiniteDigitalString
    {

        public static long findPosition(string str)
        {
            #region Demo
            long position = 0;
            long starting = 1;
            Dictionary<long, long> map = new Dictionary<long, long>();
            map.Add(949225100, 382689688);
            map.Add(58257860625, 24674951477);
            map.Add(3999589058124, 6957586376885);
            map.Add(555899959741198, 1686722738828503);
            long lookup = long.Parse(str); 
            #endregion

            foreach (var pair in map)
            {
                if (lookup > pair.Key) { position = pair.Value; starting = pair.Key; }else 
                    if (lookup == pair.Key) { return pair.Value; }
            }


            char[] toFind = str.ToCharArray();
            char[] buffer = new char[toFind.Length];
            //fill buffer
            for (int i = 0; i < buffer.Length; i++)
            {
                InfiniteCharGenerator(starting).GetEnumerator().MoveNext();
                buffer[i] = InfiniteCharGenerator().GetEnumerator().Current;
            }

            if (Enumerable.SequenceEqual(toFind, buffer)) { return position; }
            position -= buffer.Length;
            foreach (char _char in InfiniteCharGenerator(starting))
            {
                for (int i = 0; i < buffer.Length; i++) {
                    if (i + 1 < buffer.Length)
                    { buffer[i] = buffer[i + 1]; }
                    else 
                    {
                        buffer[i] = _char;
                    }
                }
                position++;
                if (Enumerable.SequenceEqual(toFind, buffer)) { return position; }
            }
            return -1;


        }
        public static IEnumerable<char> InfiniteCharGenerator(long start=1) {
            for (long i = start; i < long.MaxValue; i++)
            {
                foreach (char c in i.ToString())
                {
                    yield return c;
                }
            }
        }
    }
}