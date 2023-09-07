using LinkedList;

namespace LinkedListTest
{
    [TestClass]
    public class ChinLinkedListTest
    {
        [TestMethod]
        public void DefaultConstructorCreatesEmptyLL()
        {
            var testLL = new ChinLinkedList<int>();
            Assert.AreEqual(0, testLL.Count);
            Assert.IsNull(testLL.Head);
            Assert.IsNull(testLL.Tail);
        }
        [TestMethod]
        public void EmptyLLCallingRemoveShouldThrowInvalidOperationException()
        {
            var testLL = new ChinLinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveLast(),"Remove method on empty list did not throw an exception");
            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveFirst(), "Remove method on empty list did not throw an exception");
            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveAt(0), "Remove method on empty list did not throw an exception");

        }

        [TestMethod]
        public void ParameterizedConstructorShouldPopulateTheHeadAndTailNode()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            Assert.AreEqual(1, testLL.Count);
            Assert.IsNotNull(testLL.Head);
            Assert.IsNotNull(testLL.Tail);
            Assert.AreSame(testLL.Head, initialNode);
            Assert.AreSame(testLL.Tail, initialNode);
        }

        [TestMethod]
        public void AddFirstShouldReplaceHeadNodeAndCreateLinkToOldHead()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            var addFirstNode = new ChinNode<int>(10);

            testLL.AddFirst(addFirstNode);

            Assert.AreEqual(2, testLL.Count);
            Assert.IsNotNull(testLL.Head);
            Assert.IsNotNull(testLL.Tail);
            Assert.AreSame(testLL.Head, addFirstNode);
            Assert.AreSame(testLL.Tail, initialNode);
            Assert.AreEqual(10, testLL.Head.Content);
            Assert.AreEqual(5, testLL.Tail.Content);
        }

        [TestMethod]
        public void AddLastShouldReplaceTailNodeAndCreateLinkFromTheOldTail()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            var addLastNode = new ChinNode<int>(10);

            testLL.AddLast(addLastNode);

            Assert.AreEqual(2, testLL.Count);
            Assert.IsNotNull(testLL.Head);
            Assert.IsNotNull(testLL.Tail);
            Assert.AreSame(testLL.Head, initialNode);
            Assert.AreSame(testLL.Tail, addLastNode);
            Assert.AreEqual(5, testLL.Head.Content);
            Assert.AreEqual(10, testLL.Tail.Content);
        }

        [TestMethod]
        public void ClearMethodShouldReturnEmptyLinkedList()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            var addLastNode = new ChinNode<int>(10);
            testLL.AddLast(addLastNode);

            testLL.Clear();
            Assert.AreEqual(0,testLL.Count);
            Assert.IsNull(testLL.Head);
            Assert.IsNull(testLL.Tail);
        }


        [TestMethod]
        public void FindAllMethodShouldReturnNullIfNotFound()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddFirst(new ChinNode<int>(6));
            testLL.AddFirst(new ChinNode<int>(7));
            //finding nonexistant value
            INode<int>[] result = testLL.FindAll(1);

          
            Assert.AreEqual(0,result.Length);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindAllMethodShouldReturnOne()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddFirst(new ChinNode<int>(6));
            testLL.AddFirst(new ChinNode<int>(7));
            //finding nonexistant value
            INode<int>[] result = testLL.FindAll(5);


            Assert.AreEqual(1, result.Length);
            Assert.IsNotNull(result);
            Assert.AreEqual(result[0].Content,5);
            
        }

        [TestMethod]
        public void FindAllMethodShouldReturnMany()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddFirst(new ChinNode<int>(6));
            testLL.AddFirst(new ChinNode<int>(7));
            testLL.AddFirst(new ChinNode<int>(5));
            //finding nonexistant value
            INode<int>[] result = testLL.FindAll(5);

            Assert.AreEqual(2, result.Length);
            Assert.IsNotNull(result);
            Assert.AreEqual(result[0].Content, 5);
            Assert.AreEqual(result[1].Content, 5);
        }

        [TestMethod]
        public void FindOneMethodShouldReturnExactlyOneEvenIfThereAreMultipleMatches()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddFirst(new ChinNode<int>(6));
            testLL.AddFirst(new ChinNode<int>(7));
            testLL.AddFirst(new ChinNode<int>(5));
            //finding nonexistant value
            INode<int>? result = testLL.FindFirst(5);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, 5);
        }
        [TestMethod]
        public void FindOneMethodShouldReturnNullWhenThereAreNoMatch()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddFirst(new ChinNode<int>(6));
            testLL.AddFirst(new ChinNode<int>(7));
            testLL.AddFirst(new ChinNode<int>(5));
            //finding nonexistant value
            INode<int>? result = testLL.FindFirst(8);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void FindOneMethodShouldReturnOneWhenThereIsOneMatch()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddFirst(new ChinNode<int>(6));
            testLL.AddFirst(new ChinNode<int>(7));
            testLL.AddFirst(new ChinNode<int>(5));
            //finding nonexistant value
            INode<int>? result = testLL.FindFirst(7);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, 7);
        }

        [TestMethod]
        public void RemoveFirstShouldRemoveHeadAndMakeSecondNodeTheHead()
        {
            //Arrange
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddFirst(new ChinNode<int>(6));
            testLL.AddFirst(new ChinNode<int>(7));

            testLL.RemoveFirst();
            Assert.AreEqual(2, testLL.Count);
            Assert.AreEqual(6, testLL.Head?.Content);
            Assert.AreEqual(5, testLL.Tail?.Content);
        }

        [TestMethod]
        public void RemoveFirstShouldReturnEmptyLinkedListWhenThereIsOnlyOneNode()
        {
            var initialNode = new ChinNode<int>(5);
            var testLL = new ChinLinkedList<int>(initialNode);

            testLL.RemoveFirst();

            Assert.AreEqual(0, testLL.Count);
            Assert.IsNull(testLL.Head);
            Assert.IsNull(testLL.Tail);
        }

        [TestMethod]
        public void RemoveFirstShouldThrowExceptionIfLinkedListIsEmpty() {
            var testLL = new ChinLinkedList<int>();

            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveFirst(),"We think, if one attempts to remove an item from empty LL, it should throw Exception");
            
        }

        [TestMethod]
        public void RemoveAtShouldRemoveNodeAtGivenIndex_Index_is_zero_based()
        {
            var initialNode = new ChinNode<int>(5);//index 0
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddLast(new ChinNode<int>(6));//index 1
            testLL.AddLast(new ChinNode<int>(7));//index 2
            testLL.AddLast(new ChinNode<int>(8));//index 3
            testLL.AddLast(new ChinNode<int>(9));//index 4

            testLL.RemoveAt(2);
            
            Assert.AreEqual(4, testLL.Count);

            Assert.AreEqual(5, testLL.Head?.Content);
            Assert.AreEqual(6, testLL.Head?.Next()?.Content);
            Assert.AreEqual(8, testLL.Head?.Next()?.Next()?.Content);
            Assert.AreEqual(9, testLL.Tail?.Content);

        }

        [TestMethod]
        public void RemoveTailShouldNotThrowException()
        {
            var initialNode = new ChinNode<int>(5);//index 0
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddLast(new ChinNode<int>(6));//index 1
            testLL.AddLast(new ChinNode<int>(7));//index 2
            testLL.AddLast(new ChinNode<int>(8));//index 3
            testLL.AddLast(new ChinNode<int>(9));//index 4

            testLL.RemoveAt(4);

            Assert.AreEqual(4, testLL.Count);

            Assert.AreEqual(5, testLL.Head?.Content);
            Assert.AreEqual(6, testLL.Head?.Next()?.Content);
            Assert.AreEqual(7, testLL.Head?.Next()?.Next()?.Content);
            Assert.AreEqual(8, testLL.Tail?.Content);

        }
        [TestMethod]
        public void RemoveAtBeyondTailShouldThrowInvalidOperation()
        {
            var initialNode = new ChinNode<int>(5);//index 0
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddLast(new ChinNode<int>(6));//index 1

            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveAt(2));
        }
        [TestMethod]
        public void RemoveAtNegativeValueShouldThrowInvalidOperation()
        {
            var initialNode = new ChinNode<int>(5);//index 0
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddLast(new ChinNode<int>(6));//index 1

            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveAt(-1));
        }

        [TestMethod]
        public void RemoveAtHeadShouldWork()
        {
            var initialNode = new ChinNode<int>(5);//index 0
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddLast(new ChinNode<int>(6));//index 1
            testLL.AddLast(new ChinNode<int>(7));//index 2
            testLL.AddLast(new ChinNode<int>(8));//index 3
            testLL.AddLast(new ChinNode<int>(9));//index 4

            testLL.RemoveAt(0);

            Assert.AreEqual(4, testLL.Count);

            Assert.AreEqual(6, testLL.Head?.Content);
            Assert.AreEqual(7, testLL.Head?.Next()?.Content);
            Assert.AreEqual(8, testLL.Head?.Next()?.Next()?.Content);
            Assert.AreEqual(9, testLL.Tail?.Content);
        }

        [TestMethod]
        public void InsertAfterNodeIndexZeroShouldMakeNodeRightAfterHead()
        {
            var initialNode = new ChinNode<int>(5);//index 0
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddLast(new ChinNode<int>(6));//index 1
            testLL.AddLast(new ChinNode<int>(7));//index 2
            testLL.AddLast(new ChinNode<int>(8));//index 3
            testLL.AddLast(new ChinNode<int>(9));//index 4

            testLL.InsertAfterNodeIndex(new ChinNode<int>(99),0 );

            Assert.AreEqual(6, testLL.Count);

            Assert.AreEqual(5, testLL.Head?.Content);
            Assert.AreEqual(99, testLL.Head?.Next()?.Content);
            Assert.AreEqual(6, testLL.Head?.Next()?.Next()?.Content);
            Assert.AreEqual(9, testLL.Tail?.Content);

        }

        [TestMethod]
        public void InsertAtEndShouldBeTheSameAsAddLast()
        {
            var initialNode = new ChinNode<int>(5);//index 0
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddLast(new ChinNode<int>(6));//index 1
            testLL.AddLast(new ChinNode<int>(7));//index 2
            testLL.AddLast(new ChinNode<int>(8));//index 3
            testLL.AddLast(new ChinNode<int>(9));//index 4

            testLL.InsertAfterNodeIndex(new ChinNode<int>(99), testLL.Count-1);

            Assert.AreEqual(6, testLL.Count);

            Assert.AreEqual(5, testLL.Head?.Content);
            Assert.AreEqual(6, testLL.Head?.Next()?.Content);
            Assert.AreEqual(7, testLL.Head?.Next()?.Next()?.Content);
            Assert.AreEqual(99, testLL.Tail?.Content);

        }

        [TestMethod]
        public void InsertAtShouldBeBetweenZeroAndCountMinusOneOrItWillThrowInvalidOperation()
        {
            var initialNode = new ChinNode<int>(5);//index 0
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddLast(new ChinNode<int>(6));//index 1
            testLL.AddLast(new ChinNode<int>(7));//index 2
            testLL.AddLast(new ChinNode<int>(8));//index 3
            testLL.AddLast(new ChinNode<int>(9));//index 4

            Assert.ThrowsException<InvalidOperationException>(() => testLL.InsertAfterNodeIndex(new ChinNode<int>(99), 5));
            Assert.ThrowsException<InvalidOperationException>(() => testLL.InsertAfterNodeIndex(new ChinNode<int>(99), -1));

        }

        [TestMethod]
        public void InsertAtAnyValidPositionShouldWork()
        {
            var initialNode = new ChinNode<int>(5);//index 0
            var testLL = new ChinLinkedList<int>(initialNode);
            testLL.AddLast(new ChinNode<int>(6));//index 1
            testLL.AddLast(new ChinNode<int>(7));//index 2
            testLL.AddLast(new ChinNode<int>(8));//index 3
            testLL.AddLast(new ChinNode<int>(9));//index 4

            testLL.InsertAfterNodeIndex(new ChinNode<int>(99), 1);

            Assert.AreEqual(6, testLL.Count);

            Assert.AreEqual(5, testLL.Head?.Content);
            Assert.AreEqual(6, testLL.Head?.Next()?.Content);
            Assert.AreEqual(99, testLL.Head?.Next()?.Next()?.Content);
            Assert.AreEqual(9, testLL.Tail?.Content);

        }
    }
}