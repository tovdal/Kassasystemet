using Kassasystemet.Menu.AdminM;
using Kassasystemet.Menu.CampaignM;
using Kassasystemet.Customer;
using Kassasystemet.Products;
using Kassasystemet.VisualChanges;
using Kassasystemet.Messages;

namespace Kassasystemet.Menu.StartM
{
    public class StartMenu
    {
        public void RunMenu()
        {

            var startMenuDisplay = new StartMenuDisplay();
            var consoleWindowSize = new ConsoleWindowSize();
            var createBorder = new CreateBorder();

            var newCustomer = new NewCustomer();
            var adminMenu = new AdminMenu();
            var campaignMenu = new CampaignMenu();

            var productLoader = new ProductLoader();

            string productFilePath = "../../../Files/products.txt";

            consoleWindowSize.WindowSize();

            bool IsRunning = true;

            while (IsRunning)
            {
                startMenuDisplay.PrintOutMenu(createBorder);

                string choiceMainMenu = Console.ReadLine();
                switch (choiceMainMenu)
                {
                    case "1":
                        newCustomer.StartNewCustormer();
                        break;

                    case "2":
                        adminMenu.MenuAdmin(productLoader, productFilePath);
                        break;

                    case "3":
                        campaignMenu.MenuCampaign(productLoader, productFilePath);
                        break;

                    case "4":
                        Console.Clear();
                        Message.MessageString("Closing down the system...", 85, 20);
                        Message.MessageString("Thank you for using Cashier System 1.0!", 77, 21);
                        Console.ReadKey();
                        IsRunning = false;
                        break;

                    default:
                        Message.MessageString("Invalid choice",92, 25);
                        break;
                }
            }
        }
    }
}
