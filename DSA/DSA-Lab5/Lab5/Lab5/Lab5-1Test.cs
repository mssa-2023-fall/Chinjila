using System.Collections;

namespace Lab5
{
    [TestClass]
    public class UnitTest1
    {
        Stack<string> stack= new Stack<string>(5);
  
        [TestMethod]
        public void TestPush()
        {
            stack.Clear();
            stack.Push("Apple");
            stack.Push("Banana");
            stack.Push("Cherry");
            
            Assert.AreEqual(3, stack.Count);

        }
        [TestMethod]
        public void TestPop()
        {
            stack.Clear();
            stack.Push("Apple");
            stack.Push("Banana");
            stack.Push("Cherry");

            Assert.AreEqual("Cherry", stack.Pop());
            Assert.AreEqual(2, stack.Count);
        }
        [TestMethod]
        public void TestPeek()
        {
            stack.Clear();
            stack.Push("Apple");
            stack.Push("Banana");
            stack.Push("Cherry");

            Assert.AreEqual("Cherry", stack.Peek());
            Assert.AreEqual(3, stack.Count);
        }
        [TestMethod]
        public void TestClear()
        {
            stack.Push("Apple");
            stack.Push("Banana");
            stack.Push("Cherry");
            stack.Clear();
            Assert.AreEqual(0, stack.Count);

        }
    }
}