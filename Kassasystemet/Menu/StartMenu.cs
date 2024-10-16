using Kassasystemet.Customer;
using Kassasystemet.VisualChanges;

namespace Kassasystemet.Menu
{
    public class StartMenu
    {
        public void RunMenu()
        {
            var cashRegisterMenu = new StartMenuDisplay();
            var consoleWindow = new ConsoleWindow();
            var newCustomer = new NewCustomer();
            var consoleCenter = new ConsoleWriteLineCenter();

            consoleWindow.WindowSize();

            bool IsRunning = true;

            while (IsRunning)
            {
                cashRegisterMenu.PrintOutMenu();

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // hanterar kund
                        newCustomer.StartNewCustormer();
                        break;

                    case "2":
                        // Admin verktyg? om jag kommer så långt,
                        consoleCenter.CenterText("Admin tools under construction....");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        int lines = 20;
                        consoleCenter.SetCursorToMiddle(lines);
                        consoleCenter.CenterText("Closing down the system...");
                        consoleCenter.CenterText("Thank you for using Cashier System 1.0!");
                        Console.ReadKey();
                        IsRunning = false;
                        break;

                    default:
                        consoleCenter.CenterText("Invalid choice");
                        break;
                }
            }
        }
    }
}
