using Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Admin
{
    public class AdminDisplay
    {
        public void PrintOutAdminMenu()
        {
            var consoleCenter = new ConsoleWriteLineCenter();
            var titleDisplay = new TitleDisplay();

            Console.Clear();

            Console.SetCursorPosition(46, 3);
            titleDisplay.PrintTitle();

            consoleCenter.DrawBorder(23, 81, 30, 10);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(92, 24);
            Console.WriteLine("-:Admin:-");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(83, 26);
            Console.WriteLine("[1] Add new product");
            Console.SetCursorPosition(83, 27);
            Console.WriteLine("[2] Change name on product");
            Console.SetCursorPosition(83, 28);
            Console.WriteLine("[3] Change price on product");
            Console.SetCursorPosition(83, 29);
            Console.WriteLine("[4] Change campain on product");
            Console.SetCursorPosition(83, 30);
            Console.WriteLine("[5] Exit");


            consoleCenter.DrawBorder(33, 81, 30, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(87, 35);
            Console.Write("Pick selection: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
