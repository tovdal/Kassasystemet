using Kassasystemet.Admin.Display;
using Kassasystemet.Campaign.Visual;
using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Campaign
{
    public class CampaignAdd
    {
        public void AddCampaign(ProductManager productManager)
        {
            var campaignManager = new CampaignManager();
            var campaignVisual = new CampaignVisual();

            campaignVisual.DisplayVisualCampaign(campaignManager, productManager);

            Console.SetCursorPosition(44, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-: Add Campaign :-");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(32, 12);
            Console.Write("Enter PLU code for the product: ");
            int pluCode = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(32, 13);
            Console.Write("Enter start date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.SetCursorPosition(32, 14);
            Console.Write("Enter end date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.SetCursorPosition(32, 15);
            Console.Write("Enter discounted price: ");
            decimal discountedPrice = decimal.Parse(Console.ReadLine());

            Campaign newCampaign = new Campaign(startDate, endDate, discountedPrice, pluCode);
            campaignManager.AddCampaign(newCampaign);
            Console.SetCursorPosition(32, 16);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Campaign added successfully.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
