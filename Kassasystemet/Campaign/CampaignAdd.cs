using Kassasystemet.Campaign.Visual;
using Kassasystemet.Products;

namespace Kassasystemet.Campaign
{
    public class CampaignAdd
    {
        public void AddCampaign(ProductManager productManager)
        {
            var campaignManager = new CampaignManager();
            var campaignVisual = new CampaignVisual();

            campaignVisual.DisplayVisualCampaign(campaignManager, productManager);

            bool IsValidInput = false;
            while (!IsValidInput)
            {
                try
                {
                    Console.SetCursorPosition(44, 7);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-: Add Campaign :-");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.SetCursorPosition(32, 12);
                    Console.Write("Enter PLU code for the product: ");
                    string PLUInput = Console.ReadLine();
                    if (!int.TryParse(PLUInput, out int PLUCode) || PLUInput.Length != 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(80, 38);
                        Console.WriteLine("invalid PLU. Please enter a valid 3-digit number");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();

                        continue;
                    }
                    else
                    {
                        Console.ReadKey();
                    }

                    Console.SetCursorPosition(32, 13);
                    Console.Write("Enter start date (yyyy-mm-dd): ");
                    string startDateInput = Console.ReadLine();
                    if (!DateTime.TryParse(startDateInput, out DateTime startDate))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(80, 38);
                        Console.WriteLine("Invalid date format. Please enter a date in the format yyyy-mm-dd.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();

                        continue; // Go back to the beginning of the loop or re-prompt
                    }

                    Console.SetCursorPosition(32, 14);
                    Console.Write("Enter end date (yyyy-mm-dd): ");
                    string endDateInput = Console.ReadLine();
                    if (!DateTime.TryParse(endDateInput, out DateTime endDate))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(80, 38);
                        Console.WriteLine("Invalid date format. Please enter a date in the format yyyy-mm-dd.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();
                        continue; // Go back to the beginning of the loop or re-prompt
                    }

                    Console.SetCursorPosition(32, 15);
                    Console.Write("Enter discounted price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal discountedPrice))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(80, 38);
                        Console.WriteLine("invalid price. Please enter a valid number.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();
                        continue;
                    }

                    Campaign newCampaign = new Campaign(startDate, endDate, discountedPrice, PLUCode);
                    campaignManager.AddCampaign(newCampaign);
                    Console.SetCursorPosition(80, 38);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Campaign added successfully.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                }
                catch (ArgumentNullException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(83, 38);
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                }
                catch (OverflowException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(83, 38);
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(83, 38);
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                }
            }
        }
    }
}
