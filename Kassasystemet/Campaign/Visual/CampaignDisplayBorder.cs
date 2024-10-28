using Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Campaign.Visual
{
    public class CampaignDisplayBorder
    {
        public void ProductBorder()
        {
            var consoleCenter = new ConsoleWriteLineCenter();
            consoleCenter.DrawBorder(6, 30, 45, 28); // Products box
            consoleCenter.DrawBorder(6, 75, 48, 28); //Display Avalible campaigns
            consoleCenter.DrawBorder(6, 30, 45, 4); // Header Add products
            consoleCenter.DrawBorder(6, 123, 48, 28); // Available producs
        }
    }
}
