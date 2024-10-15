using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystemet.Kassasystemet.Customer;

namespace Kassasystemet.Kassasystemet.MenuSystem
{
    public class StartMenu
    {
        public void RunMenu()
        {
            StartMenuDisplay cashRegisterMenu = new StartMenuDisplay();
            HandleCustomer handleCustomer = new HandleCustomer();

            bool IsRunning = true;

            while (IsRunning)
            {
                cashRegisterMenu.RegisterMenu();

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // hanterar kund
                        handleCustomer.StartHandleCustomer();
                        break;

                    case "2":
                        // Admin verktyg? om jag kommer så långt,
                        Console.WriteLine("Admin tools under construction....");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Closing down the system...");
                        Console.WriteLine("Thank you for using Cashier System 1.0!");
                        Console.ReadKey();
                        IsRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
