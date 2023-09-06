using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{
    public class ShoppingCart
    {
        private Product[] Cart=new Product[0];
        public decimal CartTotal=> Cart.Length>0? Cart.Sum(x=>x.Price):0;

        public void AddItemToCart(Product item) { 
        Array.Resize(ref Cart, Cart.Length+1);
        Cart[^1] = item;
        }

        public StringBuilder PrintCart()
        {
            return PrintCart(new StringBuilder());
        }
        public StringBuilder PrintCart(StringBuilder sb)
        {   int LineId = 0;
            if (Cart.Length > 0) { 
                foreach (Product p in Cart) {
                    sb.AppendLine($"[{LineId++}] {p.Name,10} {p.Price:c2}");
                }
                sb.AppendLine($"Total {this.CartTotal:c2}");
            }
            else
            {
                sb.AppendLine("Cart is empty.");
            }

            return sb;
        }
        public override string ToString()
        {
            return PrintCart().ToString();
        }

    }
}
