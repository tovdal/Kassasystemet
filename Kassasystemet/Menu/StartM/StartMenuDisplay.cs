using Kassasystemet.VisualChanges;

namespace Kassasystemet.Menu.StartM
{
    public class StartMenuDisplay
    {
        public void PrintOutMenu(CreateBorder createBorder)
        {
            var titleDisplay = new TitleDisplay();

            Console.Clear();

            Console.SetCursorPosition(46, 3);
            titleDisplay.PrintTitle();

            createBorder.DrawBorder(23, 81, 30, 10);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(92, 24);
            Console.WriteLine("-:Menu:-");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(83, 26);
            Console.WriteLine("[1] Check out Customer");
            Console.SetCursorPosition(83, 27);
            Console.WriteLine("[2] Admin Product Tools");
            Console.SetCursorPosition(83, 28);
            Console.WriteLine("[3] Campaign Product Tools");
            Console.SetCursorPosition(83, 29);
            Console.WriteLine("[4] Exit Program\n");


            createBorder.DrawBorder(33, 81, 30, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(87, 35);
            Console.Write("Pick selection: ");
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
