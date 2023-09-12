using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib
{
    public class BinaryTree
    {
        public List<TreeNode> Nodes { get; set; }
        public BinaryTree(TreeNode Root)
        {
            this.Root = Root;
        }

        public BinaryTree(int[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)  throw new ArgumentException("invalid array");
            Nodes = new List<TreeNode>();
            this.Root = BuildTree(inputArray,0, inputArray.Length - 1,null);
        }

        private TreeNode BuildTree(int[] inputArray, int start = 0, int end = 0, TreeNode? _parent = null)
        {
            int mid = (end+start) / 2;
            if (end == start)
            { mid = start; }
                TreeNode t;
            if (_parent != null)
            {
                t = new TreeNode(inputArray[mid], _parent,level) ;
                
            } else
            {
                t = new TreeNode(inputArray[mid],null,0);
            }
            Nodes.Add(t);
            level++;
            //build left
            if (start!=mid) { 
                t.LeftChild = BuildTree(inputArray, start, mid - 1, t); }

            //build right
            if (end != mid) 
            { t.RightChild = BuildTree(inputArray, mid + 1, end, t); }
            
            return t;
        }

        public TreeNode Root { get; }
        private int level = 0;
    }
}
