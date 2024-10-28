using Kassasystemet.Admin.Display;
using Kassasystemet.Customer;
using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Campaign.Visual
{
    public class CampaignVisual
    {
        public void DisplayVisualCampaign(CampaignManager campaignManager, ProductManager productManager)
        {
            var border = new CampaignDisplayBorder();
            var campaignAvailable = new CampaignAvailable();

            Console.Clear();
            border.ProductBorder();
            campaignAvailable.DisplayAvailableCampaign(campaignManager);
            campaignAvailable.DisplayAvailableCampaignProducts(productManager);

  

        }
    }
}
