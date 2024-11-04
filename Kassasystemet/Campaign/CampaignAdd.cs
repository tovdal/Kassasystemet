using Kassasystemet.Admin.AdminAddInput;
using Kassasystemet.Campaign.CampaignInput;
using Kassasystemet.Campaign.Visual;
using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Campaign
{
    public class CampaignAdd
    {
        public void AddCampaign(ProductManager productManager)
        {
            var campaignManager = new CampaignManager();
            var campaignVisual = new CampaignVisual();
            var inputDate = new CampaignDateInput();
            var inputPLU = new AdminPLUInput(productManager);
            var inputDiscountedPrice = new CampaignPriceInput(productManager);

            bool IsValidInput = false;
            while (!IsValidInput)
            {
                Console.Clear();
                campaignVisual.DisplayVisualCampaign(campaignManager, productManager);
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Message.MessageString("-: Add Campaign :-", 44, 7);
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Message.MessageString("Enter PLU code for the product.", 32, 12);
                    Message.MessageString(": ", 32, 12);
                    int PLUCode = inputPLU.InputPLUCode();
                    DateTime startDate = inputDate.InputStartDate();
                    DateTime endDate = inputDate.InputEndDate(startDate);
                    decimal discountedPrice = inputDiscountedPrice.InputDiscountPrice(PLUCode);

                    Campaign newCampaign = new Campaign(startDate, endDate, discountedPrice, PLUCode);
                    campaignManager.AddCampaign(newCampaign);
                    DisplaySuccessMessage.SuccessMessage("Campaign added successfully.");
                    IsValidInput = true;
                }
                catch (ArgumentNullException e)
                {
                    DisplayErrorMessage.ErrorMessage(e.Message);
                }
                catch (OverflowException e)
                {
                    DisplayErrorMessage.ErrorMessage(e.Message);
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage.ErrorMessage($"An unexpected error occurred: {ex.Message}");
                }
            }
        }
    }
}
