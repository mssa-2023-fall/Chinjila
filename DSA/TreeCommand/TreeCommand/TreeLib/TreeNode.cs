using System.ComponentModel;

namespace TreeLib
{
    public class TreeNode<T> where T: FileSystemInfo
    {
        private TreeNode<T>? parentNode=null;
        private TreeNode<T>[] childrenNodes=new TreeNode<T>[0];

        public TreeNode<T>[] Children => childrenNodes;

        public bool IsRoot { get { return (parentNode == null); } }
        public T NodeContent { get; private set; }

        public TreeNode(T nodeContent, TreeNode<T>? parent=null)
        {
            this.parentNode = parent;
            this.NodeContent = nodeContent;
        }
        public void AppendChildNode(TreeNode<T> node)
        {
            Array.Resize(ref childrenNodes, childrenNodes.Length+1);
            childrenNodes[childrenNodes.Length - 1] = node;
        }
        public override string ToString()
        {
            switch (NodeContent)
            {
                case DirectoryInfo dir:
                    return $"Directory : {dir.FullName}, {dir.GetDirectories().Length} subdir and {dir.GetFiles().Length} file(s)";
                case FileSystemInfo file:
                    return $"File : {file.FullName}";
                default:
                    return $"Unknown item";
            }
            
        }

    }
}