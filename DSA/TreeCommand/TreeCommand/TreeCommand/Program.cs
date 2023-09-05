var startingDir = args[0];

PrintDir(startingDir, 0);

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

