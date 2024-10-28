using Kassasystemet.Campaign.Visual;
using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Campaign
{
    public class CampaignRemove
    {
        public void RemoveCampaign(ProductManager productManager)
        {
            var campaignManager = new CampaignManager();
            var campaignVisual = new CampaignVisual();

            campaignVisual.DisplayVisualCampaign(campaignManager, productManager);

            Console.SetCursorPosition(70, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-: Remove Campaign :-");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(57, 12);
            Console.Write("Enter PLU code for the campaign to remove: ");
            int pluCode = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(57, 13);
            Console.Write("Enter start date of the campaign to remove (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            // Call the RemoveCampaign method on the newly created instance
            bool removed = campaignManager.RemoveCampaign(pluCode, startDate);
            if (removed)
            {
                Console.SetCursorPosition(52, 16);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Campaign found and removed. Campaign removed successfully.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.SetCursorPosition(52, 16);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Campaign not found. Campaign not found with the given PLU and/or start date.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.ReadKey();
        }

    }
}
