using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet
{
    // Hanterar produkter som köpts och ansvarar för att beräkna totalsumman samt skriva ut kvittot.
    public class Receipt
    {
        public static decimal CalculateTotal(List<Product> shoppingCart)
        {
            decimal total = 0;
            foreach (var product in shoppingCart)
            {
                total += product.Price;
            }
            return total;
        }

        public static void SaveReceipt(List<Product> shoppingCart)
        {
            string receiptFilePath = $"../../../Files/RECEIPT_{DateTime.Now:yyyyMMdd}.txt";
            using (StreamWriter writer = new StreamWriter(receiptFilePath, append: true))
            {
                writer.WriteLine("==== RECEIPT ====");
                writer.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                foreach (var product in shoppingCart)
                {
                    writer.WriteLine($"{product.ProductName} - {product.Price:C}");
                }
                writer.WriteLine($"Total: {CalculateTotal(shoppingCart):C}");
                writer.WriteLine("=================\n");
                writer.WriteLine("THANKS AND WELCOME");
                writer.WriteLine("BACK TO THE SHOP\n");
                writer.WriteLine("chashier 1 1122002");
                writer.WriteLine("****ORIGINAL****");
            }
            Console.WriteLine("Receipt saved.");

            //public List<CartItem> CartItems { get; set; } = new List<CartItem>();
            //public decimal TotalAmount { get; private set; }

            //public void AddCartItem(CartItem cartItem)
            //{
            //    CartItems.Add(cartItem);
            //    TotalAmount += cartItem.Product.Price * cartItem.Quantity;
            //}

            //public void PrintReceipt()
            //{
            //    Console.WriteLine("Receipt:");
            //    foreach (var item in CartItems)
            //    {
            //        Console.WriteLine($"{item.Product.ProductName} x {item.Quantity} = {item.Product.Price * item.Quantity:C}");
            //    }
            //    Console.WriteLine($"Total: {TotalAmount:C}");
            //}
        }
    }

}
