using Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.SetCursorPosition(92, 24);
            Console.WriteLine("-:Campaign:-");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(83, 26);
            Console.WriteLine("[1] Add new Campaign");
            Console.SetCursorPosition(83, 27);
            Console.WriteLine("[2] Remove Campaign");
            Console.SetCursorPosition(83, 28);
            Console.WriteLine("[3] Back to menu");

            createBorder.DrawBorder(33, 82, 30, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(87, 35);
            Console.Write("Pick selection: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
