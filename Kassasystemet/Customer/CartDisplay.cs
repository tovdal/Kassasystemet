using Kassasystemet.Campaign;
using Kassasystemet.Messages;
using Kassasystemet.Products;
using Kassasystemet.Receipts;
using Kassasystemet.VisualChanges;

namespace Kassasystemet.Customer
{
    public class CartDisplay
    {
        public void DisplayCustomerCart(SalesReceiptCalculate salesReceiptCalculate, 
            CreateBorder createBorder, List<Product> shoppingCart)
        {
            var campaignManager = new CampaignManager();

            Console.ForegroundColor = ConsoleColor.Red;
            Message.MessageString("Cash Register - New Customer", 68, 7);
            Console.ForegroundColor = ConsoleColor.Blue;
            Message.MessageString($"Receipt     {DateTime.Now:yyyy-MM-dd HH:mm:ss}", 66, 10);
            Console.ForegroundColor = ConsoleColor.Gray;

            // starting row for products
            int currentRow = 12;

            var uniqueProducts = CartUniqProducts.GatherProducts(shoppingCart);
            //visa shoppingCart varorna i
            foreach (var products in uniqueProducts)
            {
                Console.SetCursorPosition(53, currentRow);
                decimal currentPrice = campaignManager.GetPriceWithCampaigns(products, DateTime.Now);

                if (currentPrice < products.Price)
                {
                    Console.WriteLine($"{products.ProductName} (Campaign Price!) " +
                        $"{products.Quantity} * {currentPrice:C} = {products.Quantity * currentPrice:C}");
                }
                else
                {
                    Console.WriteLine($"{products.ProductName} " +
                        $"{products.Quantity} * {currentPrice:C} = {products.Quantity * currentPrice:C}");
                }
                currentRow++;
            }

            Console.SetCursorPosition(51, 29);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Commands: <PLU> <amount> or type 'PAY' to complete");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(51, currentRow + 5);
            Message.MessageString("Total:", 51, 31);
            Message.MessageString($"{salesReceiptCalculate.CalculateTotal(shoppingCart):C}",99, 31);
            Message.MessageString("Taxes:", 51, 32);
            Message.MessageString($"{salesReceiptCalculate.CalculateTax(shoppingCart):C}",99,32);

            Message.MessageString("Command: ",51, 35);
        }
    }
}
