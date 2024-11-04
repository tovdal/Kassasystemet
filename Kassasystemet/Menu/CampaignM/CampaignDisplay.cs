using Kassasystemet.Messages;
using Kassasystemet.VisualChanges;

namespace Kassasystemet.Menu.CampaignM
{
    internal class CampaignDisplay
    {
        public void PrintOutCampaignMenu()
        {
            var createBorder = new CreateBorder();
            var titleDisplay = new TitleDisplay();

            Console.Clear();

            Console.SetCursorPosition(46, 3);
            titleDisplay.PrintTitle();

            createBorder.DrawBorder(23, 80, 34, 10);

            Console.ForegroundColor = ConsoleColor.Red;
            Message.MessageString("-:Campaign:-", 92, 24);
            Console.ForegroundColor = ConsoleColor.Gray;
            Message.MessageString("[1] Add new Campaign", 83, 26);
            Message.MessageString("[2] Remove Campaign", 83, 27);
            Message.MessageString("[3] Back to menu", 83, 28);

            createBorder.DrawBorder(33, 82, 30, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Message.MessageString("Pick selection: ", 87, 35);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
