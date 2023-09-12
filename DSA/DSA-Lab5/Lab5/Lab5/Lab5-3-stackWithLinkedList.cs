using System.Collections;

namespace Lab5
{
    [TestClass]
    public class VictorStackTest
    {
        VictorStack<string> stack= new VictorStack<string>();
  
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
        public void TestEmptyPeekShouldReturnNull() //because peek should be allowed and null is acceptable
        {
            stack.Clear();
            Assert.IsNull(stack.Peek());
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
        [TestMethod]
        public void TestEmptyStackPopThrowsException() //popping empty stack should cause exception
        {
            stack.Clear();
            Assert.ThrowsException<IndexOutOfRangeException>(() => stack.Pop()); ;

        }
    }
}