using Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Admin.Display
{
    internal class AdminAddProductDisplayBorder
    {
        public void AdminAddProductBorder()
        {
            var consoleCenter = new ConsoleWriteLineCenter();
            consoleCenter.DrawBorder(15, 74, 54, 12);
        }

    }
}
