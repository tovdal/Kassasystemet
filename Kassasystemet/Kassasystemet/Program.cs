using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Kassasystemet.Kassasystemet.Customer;
using Kassasystemet.Kassasystemet.MenuSystem;
using Kassasystemet.Kassasystemet.Receipt;
using Kassasystemet.Kassasystemet.VisualChanges;


namespace Kassasystemet.Kassasystemet
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleWindow = new ConsoleWindow();
            var calculateReceipt = new CalculateReceipt();
            var salesReceipt = new PrintSalesReceipt();
            var newCustomer = new NewCustomer();
            var consoleCenter = new ConsoleCenter();
            var titleDisplay = new TitleDisplay();
            var latestReceiptNumber = new LatestReceiptNumber();

            var startRegister = new StartMenu();
            startRegister.RunMenu(consoleWindow, calculateReceipt, salesReceipt, newCustomer, consoleCenter, titleDisplay, latestReceiptNumber);
        }
    }
}
