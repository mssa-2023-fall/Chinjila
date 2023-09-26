using Tree;

namespace IsPerfectTree
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FullTwoLevelTreeShouldBePerfect()
        {
            TreeNode root = TreeNode.Leaf().WithLeaves();
            root.left.WithLeaves();
            root.right.WithLeaves();
            root.left.left.WithLeaves();
            root.left.right.WithLeaves();
            root.left.left.left.WithLeaves();

            Assert.AreEqual(false, TreeNode.IsPerfect(root), "root with two leaves should be perfect");
        }

       
    }
}