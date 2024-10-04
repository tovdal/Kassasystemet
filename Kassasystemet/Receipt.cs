using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet
{
    public class Receipt
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal TotalAmount { get; private set; }

        public void AddCartItem(CartItem cartItem)
        {
            CartItems.Add(cartItem);
            TotalAmount += cartItem.Product.Price * cartItem.Quantity;
        }

        public void PrintReceipt()
        {
            Console.WriteLine("Receipt:");
            foreach (var item in CartItems)
            {
                Console.WriteLine($"{item.Product.ProductName} x {item.Quantity} = {item.Product.Price * item.Quantity:C}");
            }
            Console.WriteLine($"Total: {TotalAmount:C}");
        }
    }

}
