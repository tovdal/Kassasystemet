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

            bool IsValidInput = false;
            while (!IsValidInput)
            {
                Console.Clear();
                campaignVisual.DisplayVisualCampaign(campaignManager, productManager);
                try
                {
                    Console.SetCursorPosition(44, 7);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-: Remove Campaign :-");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.SetCursorPosition(32, 12);
                    Console.WriteLine("Enter PLU code for the campaign to remove.");
                    Console.SetCursorPosition(32, 13);
                    Console.Write(": ");
                    string PLUInput = Console.ReadLine();
                    if (!int.TryParse(PLUInput, out int PLUCode) || PLUInput.Length != 3)
                    {
                        DisplayErrorMessage.ErrorMessage("invalid PLU. Please enter a valid 3-digit number");
                        continue;
                    }
                    if(!productManager.IsPLUTaken(PLUCode))
                    {
                        DisplayErrorMessage.ErrorMessage("PLU does not exist. Please enter a valid PLU.");
                        continue;
                    }

                    Console.SetCursorPosition(32, 14);
                    Console.WriteLine("Enter start date of the campaign");
                    Console.SetCursorPosition(32, 15);
                    Console.WriteLine("to remove(yyyy - mm - dd)");
                    Console.SetCursorPosition(32, 16);
                    Console.Write(": ");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());

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
