using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{
    public class Catalog
    {
        public static Product[] Products = {
            new Product(1,"Apple",1.99M),
            new Product(2,"Banana",2.49M),
            new Product(3,"Orange",0.99M),
            new Product(4,"Peach",1.29M),
            new Product(5,"Watermelon",3.99M),
            new Product(6,"Grape",2.99M)
        };

        public static StringBuilder PrintMenu() {
            StringBuilder sb = new StringBuilder();
            return PrintMenu(sb);
        }
        public static StringBuilder PrintMenu(StringBuilder sb)
        {
            foreach (Product p in Products)
            {
                sb.AppendLine($"[{p.Id}] {p.Name,10} {p.Price:c2}");
            }
            return sb;
        }
    }
}
