using Kassasystemet.Messages;
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
            Message.MessageString("-:Menu:-",92, 24);
            Console.ForegroundColor = ConsoleColor.Gray;
            Message.MessageString("[1] Check out Customer", 83, 26);
            Message.MessageString("[2] Admin Product Tools", 83, 27);
            Message.MessageString("[3] Campaign Product Tools", 83, 28);
            Message.MessageString("[4] Exit Program",83, 29);


            createBorder.DrawBorder(33, 81, 30, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Message.MessageString("Pick selection: ", 87, 35);
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
