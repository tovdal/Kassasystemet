using Kassasystemet.Admin;
using Kassasystemet.Customer;
using Kassasystemet.Products;
using Kassasystemet.VisualChanges;

namespace Kassasystemet.Menu
{
    public class StartMenu
    {
        private IProductLoader _productLoader;
        public void RunMenu()
        {
            var startMenuDisplay = new StartMenuDisplay();
            var consoleWindowSize = new ConsoleWindowSize();
            var newCustomer = new NewCustomer();
            var adminMenu = new AdminMenu();
            var consoleCenter = new ConsoleWriteLineCenter();

            string productFilePath = "../../../Files/products.txt";

            consoleWindowSize.WindowSize();

            bool IsRunning = true;

            while (IsRunning)
            {
                startMenuDisplay.PrintOutMenu();

                string choiceMainMenu = Console.ReadLine();
                switch (choiceMainMenu)
                {
                    case "1":
                        // hanterar kund
                        newCustomer.StartNewCustormer();
                        break;

                    case "2":
                        // Admin verktyg? om jag kommer så långt,
                        adminMenu.MenuAdmin(_productLoader, productFilePath);
                        break;

                    case "3":
                        Console.Clear();
                        Console.SetCursorPosition(85, 20);
                        Console.WriteLine("Closing down the system...");
                        Console.SetCursorPosition(77, 21);
                        Console.WriteLine("Thank you for using Cashier System 1.0!");
                        Console.ReadKey();
                        IsRunning = false;
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
