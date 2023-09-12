using BinaryTreeLib;

namespace BInaryTreeTest
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void BinaryTreeRecursion()
        {
            BinaryTree tree = new BinaryTree(GenerateSortedNumber(100));
            Assert.IsNotNull(tree);
            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(tree.Root.Value,49);

        }

        [TestMethod]
        public void LeftTreeTraversal()
        {
            BinaryTree tree = new BinaryTree(GenerateSortedNumber(100));
            TreeNode node = tree.Root;
            while (node.LeftChild!=null) { node = node.LeftChild; };
            Assert.AreEqual(5, node.Level);
        }


        [TestMethod]
        public void TreeNodeCountShouldBe100()
        {
            BinaryTree tree = new BinaryTree(GenerateSortedNumber(100));
           
            Assert.AreEqual(100, tree.Nodes.Count);
        }


        [TestMethod]
        public void TreeNodeMaxValueShouldBe100()
        {
            BinaryTree tree = new BinaryTree(GenerateSortedNumber(100));

            Assert.AreEqual(99, tree.Nodes.Max(n=>n.Value));
        }
        [TestMethod]
        public void TreeNodeMinValueShouldBe0()
        {
            BinaryTree tree = new BinaryTree(GenerateSortedNumber(100));

            Assert.AreEqual(0, tree.Nodes.Min(n => n.Value));
        }

        [TestMethod]
        public void TreeNodeDistinctCountShouldBe100()
        {
            BinaryTree tree = new BinaryTree(GenerateSortedNumber(100));

            Assert.AreEqual(100, tree.Nodes.Distinct().Count());
        }
        public static int[] GenerateSortedNumber(int size)
        {
            var array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }
    }
}