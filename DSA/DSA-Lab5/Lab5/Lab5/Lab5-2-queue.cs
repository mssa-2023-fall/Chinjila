using System.Collections;

namespace Lab5
{
    [TestClass]
    public class QueueTests
    {
        Queue<string> testQueue = new Queue<string>();
  
        [TestMethod]
        public void TestEnqueue()
        {
            testQueue.Enqueue("Apple");
            testQueue.Enqueue("Banana");
            testQueue.Enqueue("Cherry");
            Assert.AreEqual(3, testQueue.Count);
        }
        [TestMethod]
        public void TestDequeue()
        {
            testQueue.Clear();
            testQueue.Enqueue("Apple");
            testQueue.Enqueue("Banana");
            testQueue.Enqueue("Cherry");
            Assert.AreEqual("Apple", testQueue.Dequeue());
            Assert.AreEqual(2, testQueue.Count);
        }
        [TestMethod]
        public void TestPeek()
        {
            testQueue.Clear();
            testQueue.Enqueue("Apple");
            testQueue.Enqueue("Banana");
            testQueue.Enqueue("Cherry");

            Assert.AreEqual("Apple", testQueue.Peek());
            Assert.AreEqual(3, testQueue.Count);
        }
        [TestMethod]
        public void TestClear()
        {
            testQueue.Enqueue("Apple");
            testQueue.Enqueue("Banana");
            testQueue.Enqueue("Cherry");
            testQueue.Clear();
            Assert.AreEqual(0, testQueue.Count);

        }
        [TestMethod]
        public void TestEnumerate()
        {
            testQueue.Enqueue("Apple");
            testQueue.Enqueue("Banana");
            testQueue.Enqueue("Cherry");
            int itemCounter = 0;
            string[] items = { "Apple", "Banana", "Cherry" };
            foreach (var test in testQueue)
            {
                Assert.AreEqual(test.ToString(), items[itemCounter]);
                itemCounter++;
                
            }
            Assert.AreEqual(3, itemCounter);
        }
    }
}