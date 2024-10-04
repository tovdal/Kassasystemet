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
            Console.WriteLine("Cash Register System");

            // Initialisera CashRegister och andra klasser
            var cashRegister = new CashRegister("../../../Products.txt");

            cashRegister.AddToCart(101, 2); // Exempel på PLU-kod och kvantitet
            cashRegister.AddToCart(102, 3); // Exempel på PLU-kod och kvantitet
            cashRegister.AddToCart(999, 1); // En ogiltig kod för att se felmeddelande

            // Visa totalbeloppet
            decimal total = cashRegister.GetTotalAmount();
            Console.WriteLine($"Total amount in cart: {total:C}");
            // Logik för användarinteraktion
        }
    }
}
