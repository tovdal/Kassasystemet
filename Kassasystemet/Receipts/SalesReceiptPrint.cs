using Kassasystemet.Campaign;
using Kassasystemet.Customer;
using Kassasystemet.Products;

namespace Kassasystemet.Receipts
{
    // Hanterar produkter som köpts och ansvarar för att beräkna totalsumman samt skriva ut kvittot.
    public class SalesReceiptPrint
    {
        public void SaveReceipt(List<Product> shoppingCart, SalesReceiptCalculate salesReceiptCalculate)
        {
            var uniqueProducts = CartUniqProducts.GatherProducts(shoppingCart);
            var latestReceiptNumber = new SalesReceiptLatestNumber();
            var campaignProducts = new CampaignManager();
            int receiptNumber;


            // Padding left och right.???????????????????????????????????????????????????????

            string receiptFilePath = $"../../../Files/RECEIPT_{DateTime.Now:yyyyMMdd}.txt";
            using (StreamWriter writer = new StreamWriter(receiptFilePath, append: true))
            {
                writer.WriteLine(" ____________________________________________________________");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|========================= RECEIPT =========================|");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|Super Market - NoWhere                                     |");
                writer.WriteLine("|No-Where Steet 0                                           |");
                writer.WriteLine("|234 56 No-Where                                            |");
                writer.WriteLine("|TEL NR 010-0000000                                         |");
                writer.WriteLine($"|Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}                                  |");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|------------------------                    ---------------|");
                foreach (var product in uniqueProducts)
                {
                    decimal priceWithCampaigns = campaignProducts.GetPriceWithCampaigns(product, DateTime.Now);
                    if (priceWithCampaigns < product.Price)
                    {
                        writer.WriteLine($"|{product.ProductName} (Campaign Price!) " +
                            $"{product.Quantity} * {priceWithCampaigns:C} = {product.Quantity * priceWithCampaigns:C}");
                    }
                    else
                    {
                        writer.WriteLine($"|{product.ProductName} {product.Quantity}" +
                            $" * {priceWithCampaigns:C} = {product.Quantity * priceWithCampaigns:C}");
                    }
                }
                writer.WriteLine("|                                                           |");
                writer.WriteLine($"|Articles: {shoppingCart.Count}");
                writer.WriteLine($"|Total: {salesReceiptCalculate.CalculateTotal(shoppingCart):C}");
                writer.WriteLine($"|Taxes: {salesReceiptCalculate.CalculateTax(shoppingCart):C}");
                writer.WriteLine("|-----------------------------------------------------------|");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|                     THANKS AND WELCOME                    |");
                writer.WriteLine("|                      BACK TO THE SHOP                     |");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|                         cashier 1                         |");
                writer.WriteLine($"|                     Receipt Number: " +
                    $"{receiptNumber = latestReceiptNumber.GetAndSaveLatestReceiptNumber()}                    |");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|                  ****** ORIGINAL *******                  |");
                writer.WriteLine("|                                                           |");
                writer.WriteLine("|===========================================================|");
                writer.WriteLine("|                                                           |");          
                writer.WriteLine("|___________________________________________________________|");
                writer.WriteLine("\n\n");
            }
            Console.Clear();
        }
    }
}
