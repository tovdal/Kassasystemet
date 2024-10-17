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
    public class DisplayCart
    {
        public static void DisplayCustomerCart(CalculateReceipt calculateReceipt, ConsoleWriteLineCenter consoleCenter, List<Product> shoppingCart)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(68, 8);
            Console.WriteLine("Cash Register - New Customer\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(66, 11);
            Console.WriteLine($"Receipt     {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // starting row for products
            int currentRow = 14;

            var uniqueProducts = CartUniqProducts.GatherProducts(shoppingCart);
            //visa shoppingCart varorna i
            foreach (var products in uniqueProducts)
            {
                Console.SetCursorPosition(51, currentRow);
                Console.WriteLine($"{products.ProductName} {products.Quantity} * {products.Price:C} = {products.Quantity * products.Price:C}");
                currentRow++;
            }

            Console.SetCursorPosition(51, 27);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Commands: <PLU> <amount> or type 'PAY' to complete");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(51, currentRow + 5);
            Console.SetCursorPosition(51, 29);
            Console.WriteLine("Total:");
            Console.SetCursorPosition(99, 29);
            Console.WriteLine($"{calculateReceipt.CalculateTotal(shoppingCart):C}");
            Console.SetCursorPosition(51, 30);
            Console.WriteLine("Taxes:");
            Console.SetCursorPosition(99, 30);
            Console.WriteLine($"{calculateReceipt.CalculateTax(shoppingCart):C}");

            Console.SetCursorPosition(51, 33);
            Console.Write("Command: ");
        }
    }
}
