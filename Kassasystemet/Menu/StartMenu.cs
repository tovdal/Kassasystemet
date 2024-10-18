using Kassasystemet.Admin;
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
            var adminDisplay = new AdminDisplay();
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

                        adminDisplay.DisplayAdminChoices();

                        Console.ReadKey();
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
