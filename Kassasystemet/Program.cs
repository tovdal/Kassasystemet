using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Kassasystemet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cash Register System");

            // Initialisera CashRegister och andra klasser
            var cashRegister = new CashRegister("path_to_your_products.txt");

            // Logik för användarinteraktion
        }
    }
}
