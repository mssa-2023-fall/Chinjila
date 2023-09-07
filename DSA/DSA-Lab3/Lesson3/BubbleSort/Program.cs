// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BubbleSort;
internal class Program
{
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<MSSASorts>();
    }
}