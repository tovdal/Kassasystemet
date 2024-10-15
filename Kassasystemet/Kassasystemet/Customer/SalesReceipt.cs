using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystemet.Kassasystemet.Register;

namespace Kassasystemet.Kassasystemet.Customer
{
    // Hanterar produkter som köpts och ansvarar för att beräkna totalsumman samt skriva ut kvittot.
    public class SalesReceipt
    {
        public decimal CalculateTotal(List<Product> shoppingCart)
        {
            decimal total = 0;

            foreach (var product in shoppingCart)
            {
                total += product.Price;
            }
            return total;
        }
        public decimal CalculateTax(List<Product> shoppingCart)
        {
            decimal tax = 0;

            foreach (var product in shoppingCart)
            {
                tax += product.Price;
            }
            tax *= 0.12m; 

            return tax;
        }

        public void SaveReceipt(List<Product> shoppingCart)
        {
            string receiptFilePath = $"../../../Files/RECEIPT_{DateTime.Now:yyyyMMdd}.txt";
            using (StreamWriter writer = new StreamWriter(receiptFilePath, append: true))
            {
                writer.WriteLine(" ───────────────────────────");
                writer.WriteLine("|                           |");
                writer.WriteLine("|========= RECEIPT =========|");
                writer.WriteLine("|                           |");
                writer.WriteLine("|Super Market - NoWhere     |");
                writer.WriteLine("|No-Where Steet 0           |");
                writer.WriteLine("|234 56 No-Where            |");
                writer.WriteLine("|TEL NR 010-0000000         |");
                writer.WriteLine($"|Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}  |");
                writer.WriteLine("|---------------------------|");
                writer.WriteLine("|                           |");
                foreach (var product in shoppingCart)
                {
                    writer.WriteLine($"|{product.ProductName} - {product.Price:C}");
                }
                writer.WriteLine("|                           |");
                writer.WriteLine($"|Articles: {shoppingCart.Count}");
                writer.WriteLine($"|Total: {CalculateTotal(shoppingCart):C}");
                writer.WriteLine($"|Taxes: {CalculateTax(shoppingCart):C}");
                writer.WriteLine("|                           |");
                writer.WriteLine("|---------------------------|");
                writer.WriteLine("|                           |");
                writer.WriteLine("|    THANKS AND WELCOME     |");
                writer.WriteLine("|     BACK TO THE SHOP      |");
                writer.WriteLine("|                           |");
                writer.WriteLine("|     cashier 1 1122002     |");
                writer.WriteLine("|  LÖPNUMMER ska vara här   |");
                writer.WriteLine("|                           |");
                writer.WriteLine("|  ****** ORIGINAL *******  |");
                writer.WriteLine("|                           |");
                writer.WriteLine("|===========================|");
                writer.WriteLine("|                           |");
                writer.WriteLine(" ───────────────────────────");
                writer.WriteLine("\n\n");

            }
            Console.Clear();
        }
    }
}
