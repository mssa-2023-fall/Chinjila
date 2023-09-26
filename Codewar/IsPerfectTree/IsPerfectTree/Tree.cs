using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{

    using System;
    using System.Runtime.CompilerServices;

    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        private static bool isPerfect = true;
        private static int level = 0;
        private static List<int> depth = new List<int>();

        public static bool IsPerfect(TreeNode root)
        {
            if (IsPerfectNode(root) && depth.Distinct().Count() == 1) { return true; }
            else { return false; }
        }
            public static bool IsPerfectNode(TreeNode root)
        {
            level++;
            if (root is null) { isPerfect = true; return isPerfect; }

            if (root.left != null && root.right != null)
            {
                IsPerfectNode(root.left);
                IsPerfectNode(root.right);
            }
            else if (root.left == null && root.right == null)
            {
                //this is leaf
                depth.Add(level);
            }
            else 
            {
                isPerfect = false;
            }

            level--;
     
            return isPerfect; // TODO: implementation
        }

        public static TreeNode Leaf()
        {
            return new TreeNode();
        }

        public static TreeNode Join(TreeNode left, TreeNode right)
        {
            return new TreeNode().WithChildren(left, right);
        }

        public TreeNode WithLeft(TreeNode left)
        {
            this.left = left;
            return this;
        }

        public TreeNode WithRight(TreeNode right)
        {
            this.right = right;
            return this;
        }

        public TreeNode WithChildren(TreeNode left, TreeNode right)
        {
            this.left = left;
            this.right = right;
            return this;
        }

        public TreeNode WithLeftLeaf()
        {
            return WithLeft(Leaf());
        }

        public TreeNode WithRightLeaf()
        {
            return WithRight(Leaf());
        }

        public TreeNode WithLeaves()
        {
            return WithChildren(Leaf(), Leaf());
        }
    }
}