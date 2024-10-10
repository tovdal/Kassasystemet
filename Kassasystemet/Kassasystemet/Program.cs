using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Kassasystemet.VisualChanges;

namespace Kassasystemet.Kassasystemet
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ConsoleCenter consoleCenter = new ConsoleCenter();
            TitleDisplay titleDisplay = new TitleDisplay();
            HandleCustomer handleCustomer = new HandleCustomer();

            bool IsRunning = true;

            while (IsRunning)
            {
                Console.Clear();

                titleDisplay.PrintTitle();

                int lines = 8;
                consoleCenter.SetCursorToMiddle(lines);

                
                consoleCenter.CenterText("Cashier System 1.0\n");
                consoleCenter.CenterText("[1] New Customer");
                consoleCenter.CenterText("[2] Admin Tools");
                consoleCenter.CenterText("[3] Exit\n");

                string prompt = "Pick selection: ";
                int spacesBeforeCursor = (Console.WindowWidth - prompt.Length) / 2;
                Console.SetCursorPosition(spacesBeforeCursor, Console.CursorTop + 1);
                Console.Write(prompt); //skriver ut den.

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // hanterar kund
                        handleCustomer.StartHandleCustomer();
                        break;

                    case "2":
                        // Admin verktyg? om jag kommer så långt,
                        consoleCenter.CenterText("Admin tools under construction....");
                        Console.ReadKey();
                        break;

                    case "3":
                        IsRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                //Console.WriteLine("Cash Register System");

                //// Initialisera CashRegister och andra klasser
                //var cashRegister = new CashRegister("../../../Products.txt");

                //cashRegister.AddToCart(101, 2); // Exempel på PLU-kod och kvantitet
                //cashRegister.AddToCart(102, 3); // Exempel på PLU-kod och kvantitet
                //cashRegister.AddToCart(999, 1); // En ogiltig kod för att se felmeddelande

                //// Visa totalbeloppet
                //decimal total = cashRegister.GetTotalAmount();
                //Console.WriteLine($"Total amount in cart: {total:C}");
                //// Logik för användarinteraktion
            }
        }
    }
}
