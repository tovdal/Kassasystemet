using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystemet.Kassasystemet.Customer;
using Kassasystemet.Kassasystemet.Receipt;
using Kassasystemet.Kassasystemet.VisualChanges;

namespace Kassasystemet.Kassasystemet.MenuSystem
{
    public class StartMenu
    {
        public void RunMenu(ConsoleWindow consoleWindow, CalculateReceipt calculateReceipt, SalesReceipt salesReceipt, NewCustomer handleCustomer, ConsoleCenter consoleCenter, TitleDisplay titleDisplay, LatestReceiptNumber latestReceiptNumber)
        {
            consoleWindow.WindowSize();

            StartMenuDisplay cashRegisterMenu = new StartMenuDisplay();

            bool IsRunning = true;

            while (IsRunning)
            {
                cashRegisterMenu.RegisterMenu(consoleCenter, titleDisplay);

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // hanterar kund
                        handleCustomer.StartNewCustormer(calculateReceipt, salesReceipt, consoleCenter, latestReceiptNumber);
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
