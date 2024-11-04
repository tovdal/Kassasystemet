using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Campaign
{
    internal class CampaignAvailable
    {
        public void DisplayAvailableCampaign(CampaignManager campaignManager)
        {
            Message.MessageString("Available Campaigns:", 89, 7);

            int currentRow = 10;

            foreach (var campaign in campaignManager.GetCampaigns())
            {
                Console.SetCursorPosition(77, currentRow);
                Console.WriteLine($"PLU: {campaign.PLUCode}");
                Console.SetCursorPosition(77, ++currentRow);
                Console.WriteLine($"Available between: " +
                    $"{campaign.StartDate:yyyy-MM-dd} - " +
                    $"{campaign.EndDate:yyyy-MM-dd}");
                Console.SetCursorPosition(77, ++currentRow);
                Console.WriteLine($"Campaign Price: {campaign.DiscountedPrice:C}");

                currentRow++;
            }
        }

        public void DisplayAvailableCampaignProducts(ProductManager productManager)
        {
            Message.MessageString("Available Products:", 138, 7);

            int currentRow = 10;

            foreach (var product in productManager.GetProducts())
            {
                Console.SetCursorPosition(125, currentRow);
                Console.WriteLine($"PLU: {product.PLUCode} - {product.ProductName} - {product.Price:C} - {product.Unit}");
                currentRow++;
            }
        }
    }
}

