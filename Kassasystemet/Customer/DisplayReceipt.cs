using Kassasystemet.Products;
using Kassasystemet.Receipts;
using Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Customer
{
    public class DisplayReceipt
    {
        public static void DisplayCustomerReceipt(CalculateReceipt calculateReceipt, ConsoleWriteLineCenter consoleCenter, List<Product> shoppingCart)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            consoleCenter.CenterText("Cash Register - New Customer\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            consoleCenter.CenterText("─────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            consoleCenter.CenterText($"Receipt     {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // visa shoppingCart varorna i 
            foreach (var products in shoppingCart)
            {
                consoleCenter.CenterText($"{products.ProductName} - {products.Price:C}");
            }
            consoleCenter.CenterText("");
            consoleCenter.CenterText($"Total:                 {calculateReceipt.CalculateTotal(shoppingCart):C}");
            consoleCenter.CenterText($"Taxes:                 {calculateReceipt.CalculateTax(shoppingCart):C}");
            consoleCenter.CenterText("                           ");
            Console.ForegroundColor = ConsoleColor.Green;
            consoleCenter.CenterText("Commands: <PLU> <amount> or type 'PAY' to complete");
            Console.ForegroundColor = ConsoleColor.Gray;
            consoleCenter.CenterText("─────────────────────────────────────────────────────");
            consoleCenter.CenterTextShort("Command: ");
        }

    }
}
