using Kassasystemet.Campaign.Visual;
using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Campaign
{
    public class CampaignRemove
    {
        public void RemoveCampaign(ProductManager productManager)
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
                    Console.WriteLine("-: Remove Campaign :-");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.SetCursorPosition(32, 12);
                    Console.Write("Enter PLU code for the campaign to remove: ");
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

                    Console.SetCursorPosition(32, 13);
                    Console.Write("Enter start date of the campaign to remove (yyyy-mm-dd): ");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());

                    // Call the RemoveCampaign method on the newly created instance
                    bool removed = campaignManager.RemoveCampaign(PLUCode, startDate);
                    if (removed)
                    {
                        Console.SetCursorPosition(80, 38);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("Campaign found and removed. Campaign removed successfully.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.SetCursorPosition(80, 38);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Campaign not found. Campaign not found" +
                            " with the given PLU and/or start date.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
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
