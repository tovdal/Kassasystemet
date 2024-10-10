using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet.Customer
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

        public void SaveReceipt(List<Product> shoppingCart)
        {
            string receiptFilePath = $"../../../Files/RECEIPT_{DateTime.Now:yyyyMMdd}.txt";
            using (StreamWriter writer = new StreamWriter(receiptFilePath, append: true))
            {
                writer.WriteLine("───────────────────────");
                writer.WriteLine("======= RECEIPT =======");
                writer.WriteLine("Super Market - NoWhere");
                writer.WriteLine("No-Where Steet 0");
                writer.WriteLine("234 56 No-Where");
                writer.WriteLine("TEL NR 010-0000000");
                writer.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");
                foreach (var product in shoppingCart)
                {
                    writer.WriteLine($"{product.ProductName} - {product.Price:C}");
                }
                writer.WriteLine($"\n{shoppingCart.Count} : articles");
                writer.WriteLine($"Total: {CalculateTotal(shoppingCart):C}\n");
                writer.WriteLine("-----------------------");
                writer.WriteLine("THANKS AND WELCOME");
                writer.WriteLine("BACK TO THE SHOP\n");
                writer.WriteLine("chashier 1 1122002");
                writer.WriteLine("LÖPNUMMER ska vara här");
                writer.WriteLine("****** ORIGINAL *******");
                writer.WriteLine("=======================");
                writer.WriteLine("───────────────────────");
                writer.WriteLine("\n\n");

            }
            Console.Clear();
        }
    }
}
