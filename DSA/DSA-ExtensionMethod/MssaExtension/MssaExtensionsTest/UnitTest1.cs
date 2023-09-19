using MssaExtension;
using System.Linq;
namespace MssaExtensionsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetShaStringExtension()
        {
            var _file = new FileInfo(@"C:\test\oscar_age_male.csv");
            var _file2 = new FileInfo(@"C:\test\a.png");

            Assert.AreEqual("rSSHX5rkP6Y4BrmT3rYYmGmqInc=", _file.GetSHAString(StringFormat.Base64));
            Assert.AreEqual("ad24875f9ae43fa63806b993deb6189869aa2277", _file.GetSHAString(StringFormat.Hex));
            Assert.AreEqual("I47GbDrg8N9/N2AbrTVFp7UJu+0=", _file2.GetSHAString(StringFormat.Base64));
            Assert.AreEqual("238ec66c3ae0f0df7f37601bad3545a7b509bbed", _file2.GetSHAString(StringFormat.Hex));
        }

        [TestMethod]
        public void CustomLinqMethods()
        {
            IEnumerable<int> inputs1 = new[] { 1, 2, 3, 4, 5, 6, 7 };
             var median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(4, median);
        }
        [TestMethod]
        public void CustomLinqMethods2()
        {
            IEnumerable<double> inputs1 = new[] { 1, 2.5, 3.9, 4.7, 5.2, 6.7, 7.5,8.9};
            var median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(5.2, median);
        }
        [TestMethod]
        public void CustomLinqMethods3()
        {
            IEnumerable<float> inputs1 = new[] { 1f, 2.5f, 3.9f, 4.7f, 5.2f, 6.7f, 7.5f, 8.9f };
            var median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(5.2f, median);
        }
        [TestMethod]
        public void CustomLinqMethods4()
        {
            IEnumerable<decimal> inputs1 = new[] { 1m, 2.5m, 3.9m, 4.7m, 5.2m, 6.7m, 7.5m, 8.9m };
            var median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(5.2m, median);
        }

        [TestMethod]
        public void TestDictionaryIndexer()
        {
            Dictionary<FileInfo,Stream> dictionary = new Dictionary<FileInfo,Stream>();
            var _file = new FileInfo(@"C:\test\oscar_age_male.csv");
            dictionary.Add(_file,_file.OpenRead());
            Assert.IsTrue(dictionary[_file].Length == _file.Length);
            
        }
    }
}