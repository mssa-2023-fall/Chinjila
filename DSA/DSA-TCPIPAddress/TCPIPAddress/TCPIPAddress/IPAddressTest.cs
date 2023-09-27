namespace TCPIPAddress
{
    [TestClass]
    public class IPAddressTest
    {
        static string ValidIP = "192.168.150.3/24";
        static string InvalidIP = "192.168.150.3.4/24";
        static string InvalidIP2 = "192.168../24";
        static string InvalidIP3 = "192.168.150.3/35";
        [TestMethod]
        public void ConstructorWithCorrectInput()
        {
            Assert.IsNotNull(new IPAddress(ValidIP));
        }
        [TestMethod]
        public void ConstructorWithInCorrectAddress()
        {
            Assert.ThrowsException<ArgumentException>(() => new IPAddress(InvalidIP)); ;
        }
        [TestMethod]
        public void ConstructorWithInCorrectAddressShort()
        {
            Assert.ThrowsException<ArgumentException>(() => new IPAddress(InvalidIP2)); ;
        }
        [TestMethod]
        public void ConstructorWithInCorrectMask()
        {
            Assert.ThrowsException<ArgumentException>(() => new IPAddress(InvalidIP3)); ;
        }

        [TestMethod]
        public void NetworkIDTest()
        {
            Assert.AreEqual("192.168.150.0",new IPAddress(ValidIP).NetworkID);
            Assert.AreEqual("10.0.0.0", new IPAddress("10.1.2.3/8").NetworkID);
            Assert.AreEqual("172.16.0.0", new IPAddress("172.16.1.1/16").NetworkID);
            Assert.AreEqual("172.16.128.0", new IPAddress("172.16.129.1/17").NetworkID);
            Assert.AreEqual("172.16.129.4", new IPAddress("172.16.129.5/30").NetworkID);
        }
        [TestMethod]
        public void HostCountTest()
        {
            Assert.AreEqual(256, new IPAddress("10.1.2.3/24").NumberOfAddress);
            Assert.AreEqual(256*256, new IPAddress("10.1.2.3/16").NumberOfAddress);
            Assert.AreEqual(4, new IPAddress("10.1.2.3/30").NumberOfAddress);
            Assert.AreEqual(8, new IPAddress("10.1.2.3/29").NumberOfAddress);
            Assert.AreEqual(1, new IPAddress("10.1.2.3/32").NumberOfAddress);
            Assert.AreEqual(256d * 256 * 256 * 256, new IPAddress("10.1.2.3/0").NumberOfAddress);
        }

        [TestMethod]
        public void LastAddressTest()
        {
            //Assert.AreEqual("10.1.2.255", new IPAddress("10.1.2.3/24").LastAddress);
            //Assert.AreEqual("10.1.255.255", new IPAddress("10.1.2.3/16").LastAddress);
            //Assert.AreEqual("10.1.2.3", new IPAddress("10.1.2.3/30").LastAddress);
            //Assert.AreEqual("10.255.255.255", new IPAddress("10.1.2.3/8").LastAddress);
            Assert.AreEqual("192.168.1.255", new IPAddress("192.168.1.5/24").LastAddress);
        }

    }
}