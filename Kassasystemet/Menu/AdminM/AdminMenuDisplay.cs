﻿using Kassasystemet.VisualChanges;

namespace Kassasystemet.Menu.AdminM
{
    public class AdminMenuDisplay
    {
        public void PrintOutAdminMenu()
        {
            var createBorder = new CreateBorder();
            var titleDisplay = new TitleDisplay();

            Console.Clear();

            Console.SetCursorPosition(46, 3);
            titleDisplay.PrintTitle();

            createBorder.DrawBorder(23, 80, 34, 10);

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
            Console.WriteLine("[4] Exit");


            createBorder.DrawBorder(33, 82, 30, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(87, 35);
            Console.Write("Pick selection: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
