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
            Console.SetCursorPosition(51, 9);
            Console.WriteLine("Cash Register - New Customer\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(51, 11);
            Console.WriteLine("─────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(51, 12);
            Console.WriteLine($"Receipt     {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // starting row for products
            int currentRow = 14;

            // visa shoppingCart varorna i 
            foreach (var products in shoppingCart)
            {
                Console.SetCursorPosition(51, currentRow);
                Console.WriteLine($"{products.ProductName} - {products.Price:C}");
                currentRow++;
            }

           
            Console.SetCursorPosition(51, 29);
            Console.WriteLine($"Total:                 {calculateReceipt.CalculateTotal(shoppingCart):C}");
            Console.SetCursorPosition(51, 30);
            Console.WriteLine($"Taxes:                 {calculateReceipt.CalculateTax(shoppingCart):C}");
            Console.SetCursorPosition(51, currentRow + 4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Commands: <PLU> <amount> or type 'PAY' to complete");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(51, currentRow + 5);
            Console.WriteLine("─────────────────────────────────────────────────────");
            Console.SetCursorPosition(51, 33);
            Console.Write("Command: ");
        }
                //consoleCenter.DrawBorder(7, 50, 65, 25); // New Customer
                //consoleCenter.DrawBorder(7, 115, 35, 25); //Available products
                //consoleCenter.DrawBorder(32, 50, 100, 6); //Comand box
                //consoleCenter.DrawBorder(27, 50, 65, 5); // total box.
    }
}
