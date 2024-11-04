using Kassasystemet.Messages;
using Kassasystemet.VisualChanges;

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
            Message.MessageString("-:Admin:-", 92, 24);
            Console.ForegroundColor = ConsoleColor.Gray;
            Message.MessageString("[1] Add new product", 83, 26);
            Message.MessageString("[2] Change name on product",83, 27);
            Message.MessageString("[3] Change price on product", 83, 28);
            Message.MessageString("[4] Back to menu", 83, 29);


            createBorder.DrawBorder(33, 82, 30, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Message.MessageString("Pick selection: ", 87, 35);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
