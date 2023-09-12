namespace BinaryTreeLib
{
    public class TreeNode
    {
        public TreeNode? Parent;
        public TreeNode? LeftChild;
        public TreeNode? RightChild;
        public bool IsRoot => Parent == null;
        public bool IsLeaf => LeftChild == null && RightChild == null;
        public TreeNode(int value)
        {
            Value = value;
        }
   
        public TreeNode(int _value, TreeNode _parent, int _level)
        {
            this.Parent = _parent;
            Level = _level;
            Value = _value;

        }

        public int Value { get; }
        public int Level { get; set; }
        
        public override string ToString()
        {
            return $"Node:{Value}, Parent: {this.Parent?.Value}, Left:{this.LeftChild?.Value}, Right{this.RightChild?.Value}";
        }
    }
}