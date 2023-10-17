// See https://aka.ms/new-console-template for more information
using SampleAbstract;

Shape s = GetRandomShape();//new VC();

s.CreateShape(new Line { Length=5 });
Console.WriteLine($"Shape is a {s.Name}. It has {s.Sides} sides with perimeter of {s.GetPerimeter()} and area of {s.GetArea()}");
Shape GetRandomShape()
{
    //string[] classNames= Directory.GetFiles(@"C:\Repos\ReactSample\SampleAbstract\SampleAbstract\")
    //    .Where(f=>f.EndsWith("cs") && f.Length==5)
    //    .Select(f=>Path.GetFileNameWithoutExtension(f))
    //    .ToArray();

    
    List<Shape> shapes = new List<Shape>();
    shapes.Add(new VC());
    shapes.Add(new AG());
    shapes.Add(new BM());
    shapes.Add(new CR());
    shapes.Add(new EM());
    shapes.Add(new GS());
    shapes.Add(new JM());
    shapes.Add(new LN());
    shapes.Add(new MA());
    shapes.Add(new XH());


    //foreach (var item in classNames)
    //{
    //    Type? t = Type.GetType(item);
    //    shapes.Add(Activator.CreateInstance(t) as Shape);
    //}
    return shapes[Random.Shared.Next(0,shapes.Count)];
}