using TreeLib;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.IO;

var startingDir = args[0];

TreeNode<FileSystemInfo> rootNode = new(new DirectoryInfo(startingDir));
BuildTree(rootNode);
PrintTree(rootNode);
Console.WriteLine("Done");


void PrintTree(TreeNode<FileSystemInfo> tree,int level=0)
{
    Console.WriteLine(new String('-',level) + tree.ToString());
    level++;
    foreach (var item in tree.Children)
    {
        PrintTree(item,level);
    }
}


void BuildTree(TreeNode<FileSystemInfo> parent)
{
        DirectoryInfo? dir = parent.NodeContent as DirectoryInfo;
   
        if (dir?.GetDirectories().Length > 0)
        {
            foreach (var directory in dir.GetDirectories())
            {
                var dirNode = new TreeNode<FileSystemInfo>(directory, parent);
                parent.AppendChildNode(dirNode);
                BuildTree(dirNode);
            }
        }
        if (dir?.GetFiles().Length > 0)
        {
            foreach (var file in dir.GetFiles())
            {
                var fileNode = new TreeNode<FileSystemInfo>(file, parent);
                parent.AppendChildNode(fileNode);

            }
        }
}



