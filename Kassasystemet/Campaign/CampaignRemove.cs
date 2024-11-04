using Kassasystemet.Campaign.CampaignInput;
using Kassasystemet.Campaign.Visual;
using Kassasystemet.Messages;
using Kassasystemet.Products;
using System.ComponentModel;

namespace Kassasystemet.Campaign
{
    public class CampaignRemove
    {
        public void RemoveCampaign(ProductManager productManager)
        {
            var campaignManager = new CampaignManager();
            var campaignVisual = new CampaignVisual();

            var inputPLU = new CampaignPLUCodeInput(productManager);
            var inputStartDate = new CampaignDateInput();

            bool IsValidInput = false;
            while (!IsValidInput)
            {
                Console.Clear();
                campaignVisual.DisplayVisualCampaign(campaignManager, productManager);
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Message.MessageString("-: Remove Campaign :-", 44, 7);
                    Console.ForegroundColor = ConsoleColor.Gray;

                    int PLUCode = inputPLU.InputPLUCode();
                    DateTime startDate = inputStartDate.InputStartDate();

                    bool removed = campaignManager.RemoveCampaign(PLUCode, startDate);
                    if (removed)
                    {
                        DisplaySuccessMessage.SuccessMessage("Campaign found and removed. Campaign removed successfully.");
                    }
                    else
                    {
                        DisplayErrorMessage.ErrorMessage("Campaign not found. Campaign not found" +
                            " with the given PLU and/or start date.");
                    }
                    IsValidInput = true;
                    Console.ReadKey();
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
