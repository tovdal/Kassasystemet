using Kassasystemet.Products;
using Kassasystemet.Receipts;
using Kassasystemet.VisualChanges;

namespace Kassasystemet.Customer
{
    public class CartDisplay
    {
        public static void DisplayCustomerCart(SalesReceiptCalculate calculateReceipt, ConsoleWriteLineCenter consoleCenter, List<Product> shoppingCart)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(68, 7);
            Console.WriteLine("Cash Register - New Customer\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(66, 10);
            Console.WriteLine($"Receipt     {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // starting row for products
            int currentRow = 12;

            var uniqueProducts = CartUniqProducts.GatherProducts(shoppingCart);
            //visa shoppingCart varorna i
            foreach (var products in uniqueProducts)
            {
                Console.SetCursorPosition(53, currentRow);
                Console.WriteLine($"{products.ProductName} {products.Quantity} * {products.Price:C} = {products.Quantity * products.Price:C}");
                currentRow++;
            }

            Console.SetCursorPosition(51, 29);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Commands: <PLU> <amount> or type 'PAY' to complete");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(51, currentRow + 5);
            Console.SetCursorPosition(51, 31);
            Console.WriteLine("Total:");
            Console.SetCursorPosition(99, 31);
            Console.WriteLine($"{calculateReceipt.CalculateTotal(shoppingCart):C}");
            Console.SetCursorPosition(51, 32);
            Console.WriteLine("Taxes:");
            Console.SetCursorPosition(99, 32);
            Console.WriteLine($"{calculateReceipt.CalculateTax(shoppingCart):C}");

            Console.SetCursorPosition(51, 35);
            Console.Write("Command: ");
        }
    }
}
