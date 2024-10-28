
using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Kassasystemet.Campaign
{
    internal class CampaignAvailable
    {
        public void DisplayAvailableCampaign(CampaignManager campaignManager)
        {
            Console.SetCursorPosition(89, 7);
            Console.WriteLine("Available Campaigns:");

            int currentRow = 10;

            foreach (var campaign in campaignManager.GetCampaigns())
            {
                Console.SetCursorPosition(77, currentRow);
                Console.WriteLine($"PLU: {campaign.PLUCode}");
                Console.SetCursorPosition(77, ++currentRow);
                Console.WriteLine($"Available between: {campaign.StartDate:yyyy-MM-dd} - {campaign.EndDate:yyyy-MM-dd}");
                Console.SetCursorPosition(77, ++currentRow);
                Console.WriteLine($"Campaign Price: {campaign.DiscountedPrice:C}");

                currentRow++;
            }
        }

        public void DisplayAvailableCampaignProducts(ProductManager productManager)
        {
            Console.SetCursorPosition(138, 7);
            Console.WriteLine("Available Products:");

            int currentRow = 10;

            foreach (var product in productManager.GetProducts())
            {
                Console.SetCursorPosition(125, currentRow);
                Console.WriteLine($"PLU: {product.PLUCode} - {product.ProductName} - {product.Unit}");
                currentRow++;
            }
        }
    }
}

