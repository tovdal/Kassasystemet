using Kassasystemet.Campaign;
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
            var campaignAdd = new CampaignAdd();
            var campaignRemove = new CampaignRemove();

            bool IsRunningCampaign = true;

            while (IsRunningCampaign)
            {
                campaignDisplay.PrintOutCampaignMenu();

                string choiceCampaignMenu = Console.ReadLine();
                switch (choiceCampaignMenu)
                {
                    case "1":
                        campaignAdd.AddCampaign();
                        break;

                    case "2":
                        campaignRemove.RemoveCampaign();
                        break;

                    case "3":
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
