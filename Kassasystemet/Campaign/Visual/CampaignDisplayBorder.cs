using Kassasystemet.VisualChanges;

namespace Kassasystemet.Campaign.Visual
{
    public class CampaignDisplayBorder
    {
        public void ProductBorder()
        {
            var createBorder = new CreateBorder();
            createBorder.DrawBorder(6, 30, 45, 28); // Products box
            createBorder.DrawBorder(6, 75, 48, 28); //Display Avalible campaigns
            createBorder.DrawBorder(6, 30, 45, 4); // Header Add products
            createBorder.DrawBorder(6, 123, 48, 28); // Available producs
        }
    }
}
