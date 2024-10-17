using Kassasystemet.VisualChanges;

namespace Kassasystemet.Menu
{
    public class StartMenuDisplay
    {
        public void PrintOutMenu()
        {
            var consoleCenter = new ConsoleWriteLineCenter();
            var titleDisplay = new TitleDisplay();

            Console.Clear();

            titleDisplay.PrintTitle();

            consoleCenter.DrawBorder(23, 81, 30, 10);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(92, 24);
            Console.WriteLine("-:Menu:-");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(88, 27);
            Console.WriteLine("[1] New Customer");
            Console.SetCursorPosition(88, 28);
            Console.WriteLine("[2] Admin Tools ");
            Console.SetCursorPosition(88, 29);
            Console.WriteLine("[3] Exit\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(87, 35);
            Console.Write("Pick selection: ");
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
