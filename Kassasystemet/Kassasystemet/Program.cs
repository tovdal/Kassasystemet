using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Kassasystemet.Kassasystemet
{
    class Program
    {
        static void Main(string[] args)
        {
            string productFilePath = "../../../Files/products.txt"; //Filvägen till produkterna
            CashRegister register = new CashRegister(productFilePath);
            bool IsRunning = true;

            while (IsRunning)
            {
                Console.Clear();
                Console.WriteLine("Cashier System 1.0\n");
                Console.WriteLine("[1] New Customer");
                Console.WriteLine("[2] Admin Tools");
                Console.WriteLine("[3] Exit\n");

                Console.WriteLine("Pick selection: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // hanterar kund
                        break;
                    case "2":
                        // Admin verktyg? om jag kommer så långt,
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
