using Kassasystemet.Products;

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
