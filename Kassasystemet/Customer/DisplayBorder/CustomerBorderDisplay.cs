using Kassasystemet.Products;
using Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Customer.DisplayBorder
{
    public class CustomerBorderDisplay
    {
        public static void CustomerDrawBorder(ConsoleWriteLineCenter consoleCenter)
        {
            consoleCenter.DrawBorder(6, 50, 65, 26); // Products box
            consoleCenter.DrawBorder(6, 115, 35, 28); //Available products
            consoleCenter.DrawBorder(34, 50, 100, 3); //Comand box
            consoleCenter.DrawBorder(30, 50, 65, 4); // total box and taxes.
            consoleCenter.DrawBorder(6, 50, 65, 4); // Header - Cash Regiser

        }

    }
}
