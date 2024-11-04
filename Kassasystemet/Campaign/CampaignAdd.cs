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

            bool IsValidInput = false;
            while (!IsValidInput)
            {
                Console.Clear();
                campaignVisual.DisplayVisualCampaign(campaignManager, productManager);
                try
                {
                    Console.SetCursorPosition(44, 7);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-: Add Campaign :-");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.SetCursorPosition(32, 12);
                    Console.WriteLine("Enter PLU code for the product.");
                    Console.SetCursorPosition(32, 13);
                    Console.Write(": ");
                    string PLUInput = Console.ReadLine();
                    if (!int.TryParse(PLUInput, out int PLUCode) || PLUInput.Length != 3)
                    {
                        DisplayErrorMessage.ErrorMessage("invalid PLU. Please enter a valid 3-digit number");
                        continue;
                    }
                    if (!productManager.IsPLUTaken(PLUCode))
                    {
                        DisplayErrorMessage.ErrorMessage("PLU does not exist. Please enter a valid PLU.");
                        continue;
                    }

                    Console.SetCursorPosition(32, 14);
                    Console.WriteLine("Enter start date (yyyy-mm-dd).");
                    Console.SetCursorPosition(32, 15);
                    Console.Write(": ");
                    string startDateInput = Console.ReadLine();
                    if (!DateTime.TryParse(startDateInput, out DateTime startDate))
                    {
                        DisplayErrorMessage.ErrorMessage("Invalid date format. " +
                            "Please enter a date in the format yyyy-mm-dd.");
                        continue; 
                    }

                    Console.SetCursorPosition(32, 16);
                    Console.WriteLine("Enter end date (yyyy-mm-dd).");
                    Console.SetCursorPosition(32, 17);
                    Console.Write(": ");
                    string endDateInput = Console.ReadLine();
                    if (!DateTime.TryParse(endDateInput, out DateTime endDate))
                    {
                        DisplayErrorMessage.ErrorMessage("Invalid date format. " +
                            "Please enter a date in the format yyyy-mm-dd.");
                        continue; 
                    }

                    Console.SetCursorPosition(32, 18);
                    Console.WriteLine("Enter discounted price.");
                    Console.SetCursorPosition(32, 19);
                    Console.Write(": ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal discountedPrice))
                    {
                        DisplayErrorMessage.ErrorMessage("invalid price. Please enter a valid number.");
                        continue;
                    }
                    if (discountedPrice >= productManager.GetProductPrice(PLUCode))
                    {
                        DisplayErrorMessage.ErrorMessage("Discounted price cannot be equal to" +
                            " or greater than the original price.");
                        continue;
                    }

                    Campaign newCampaign = new Campaign(startDate, endDate, discountedPrice, PLUCode);
                    campaignManager.AddCampaign(newCampaign);
                    DisplaySuccessMessage.SuccessMessage("Campaign added successfully.");
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
