using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Menu.CampaignM
{
    public class CampaignMenu
    {
        public void MenuCampaign()
        {
            var campaignDisplay = new CampaignDisplay();
            bool IsRunningCampaign = true;

            while (IsRunningCampaign)
            {
                campaignDisplay.PrintOutCampaignMenu();

                string choiceCampaignMenu = Console.ReadLine();
                switch (choiceCampaignMenu)
                {
                    case "1":
                        // Add campaign
                        break;

                    case "2":
                        // change campaign
                        
                        break;

                    case "3":
                        // remove campaign
                        break;

                    case "4":
                        // back to menu
                        IsRunningCampaign = false;
                        break;

                    default:
                        Console.SetCursorPosition(92, 25);
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
