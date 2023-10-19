using DynamicFileReader;

dynamic rFile = new ReadOnlyFile(@"..\..\..\TextFile1.txt");
foreach (string line in rFile.Customer)
{
    Console.WriteLine(line);
}
Console.WriteLine("----------------------------");
foreach (string line in rFile.Supplier(StringSearchOption.StartsWith, true))
{
    Console.WriteLine(line);
}