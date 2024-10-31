using Kassasystemet.Campaign;
using Kassasystemet.Products;
using Kassasystemet.Products.Interface;

namespace Kassasystemet.Menu.CampaignM
{
    public class CampaignMenu
    {
        public void MenuCampaign(IProductLoader productLoader, string filePath)
        {
            var productManager = new ProductManager(productLoader, filePath);
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
                        campaignAdd.AddCampaign(productManager);
                        break;

                    case "2":
                        campaignRemove.RemoveCampaign(productManager);
                        break;

                    case "3":
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
