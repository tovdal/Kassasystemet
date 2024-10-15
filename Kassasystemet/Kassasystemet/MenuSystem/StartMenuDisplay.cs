using Kassasystemet.Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet.MenuSystem
{
    public class StartMenuDisplay
    {
        public void RegisterMenu(ConsoleCenter consoleCenter, TitleDisplay titleDisplay)
        {
            Console.Clear();

            titleDisplay.PrintTitle();

            int lines = 8;
            consoleCenter.SetCursorToMiddle(lines);

            Console.WriteLine("\n");
            consoleCenter.CenterText("-:Menu:-\n");
            consoleCenter.CenterText("[1] New Customer");
            consoleCenter.CenterText("[2] Admin Tools ");
            consoleCenter.CenterText("[3] Exit      \n");

            string prompt = "Pick selection: ";
            int spacesBeforeCursor = (Console.WindowWidth - prompt.Length) / 2;
            Console.SetCursorPosition(spacesBeforeCursor, Console.CursorTop + 1);
            Console.Write(prompt); //skriver ut den.

        }
    }
}
