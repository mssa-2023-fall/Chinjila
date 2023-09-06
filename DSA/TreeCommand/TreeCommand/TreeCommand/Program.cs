using TreeLib;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.IO;

var startingDir = args[0];

TreeNode<FileSystemInfo> tree = new(new DirectoryInfo(startingDir));
BuildTree(tree);
PrintTree(tree);
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


void BuildTree(TreeNode<FileSystemInfo> tree)
{
    switch (tree.NodeContent)
    {
        case DirectoryInfo dir:
            if (dir.GetDirectories().Length > 0)
            {
                foreach (var directory in dir.GetDirectories()) {
                    var dirNode = new TreeNode<FileSystemInfo>(directory, tree);
                    tree.AppendChildNode(dirNode);
                    BuildTree(dirNode);
                }
            }
            if (dir.GetFiles().Length > 0)
            {
                foreach (var file in dir.GetFiles())
                {
                    var fileNode = new TreeNode<FileSystemInfo>(file, tree);
                    tree.AppendChildNode(fileNode);
                    BuildTree(fileNode);
                }
            }
            break;
        //case FileInfo file:
        //    var childFileNode = new TreeNode<FileSystemInfo>(file, tree);
        //    tree.AppendChildNode(childFileNode);
        //    break;
        default:
            break;
    }
    
}

//PrintDir(startingDir, 0); //old implementation, string based

void PrintDir(string startingDir, int level)
{
    string[] subdirs = Directory.GetDirectories(startingDir);
    if (subdirs.Length == 0) return;
    foreach (var item in subdirs)
    {
        try
        {
            Console.WriteLine($"{new String('-', level)} {item}");
            PrintDir(item, level + 1);
        }
        catch (Exception)
        {

            continue;
        }
    }
}

