using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet.VisualChanges
{
    public class TitleDisplay
    {
        ConsoleCenter consoleCenter = new ConsoleCenter();
        // Ascii konst.
        public void PrintTitle()
        {
            Console.WriteLine("\n\n\n\n");
            consoleCenter.CenterText("┌───────────────────────────────────┐");
            consoleCenter.CenterText("│            CASH REGISTER          │");
            consoleCenter.CenterText("│                1.0                │");
            consoleCenter.CenterText("└───────────────────────────────────┘");
            consoleCenter.CenterText(" ");
        }
    }
}
