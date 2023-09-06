// See https://aka.ms/new-console-template for more information

using GroceryLib;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime.CompilerServices;

ShoppingCart cart = new ShoppingCart();
bool addMoreItem = false;
do {

    var sb = Catalog.PrintMenu();
    Console.WriteLine(sb.ToString().TrimEnd());
    Console.WriteLine("Enter Item ID:");
    int ItemID = 0;
    try
    {
        ItemID = Convert.ToInt32(Console.ReadLine());
        if (!Catalog.Products.Any(p => p.Id == ItemID)) throw new Exception("Bad item id");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        addMoreItem = true;
        continue;
    }

    cart.AddItemToCart(Catalog.Products[ItemID - 1]);
    Console.WriteLine("Add more item to cart? Y to add more, any other key to print receipt.");
    if (Console.ReadKey() == new ConsoleKeyInfo('y', ConsoleKey.Y, false, false, false)) {
        addMoreItem = true;
    } else { addMoreItem = false; }
} while (addMoreItem);
Console.WriteLine("\n************receipt*********");
Console.WriteLine(cart.PrintCart().ToString());