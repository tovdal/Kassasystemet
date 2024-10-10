using Kassasystemet.VisualChanges;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kassasystemet.Kassasystemet
{
    public class HandleCustomer
    {
        public void StartHandleCustomer()
        {
            // hanterar kund
            string productFilePath = "../../../Files/products.txt"; //Filvägen till produkterna

            CashRegister register = new CashRegister(productFilePath);
            Receipt receipt = new Receipt();
            List<Product> shoppingCart = new List<Product>();
            ConsoleCenter consoleCenter = new ConsoleCenter();

            string input;
            bool IsPaymentCompleted = false;

            do
            {
                Console.Clear();

                int lines = 20;
                consoleCenter.SetCursorToMiddle(lines);

                consoleCenter.CenterText("───────────────────────────────────");

                consoleCenter.CenterText("Cash Register\n");
                consoleCenter.CenterText($"Receipt     {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

                foreach (var products in shoppingCart)
                {
                    consoleCenter.CenterText($"{products.ProductName} - {products.Price:C}");
                }

                consoleCenter.CenterText($"Total: {Receipt.CalculateTotal(shoppingCart):C}");
                consoleCenter.CenterText("<PLU code> or type 'PAY' to complete");
                consoleCenter.CenterText("Command: ");
                consoleCenter.CenterText("───────────────────────────────────");
                input = Console.ReadLine();


                if (input.ToUpper() != "PAY")
                {
                    try
                    {
                        string[] parts = input.Split(' ');
                        int pluCode = int.Parse(parts[0]);
                        int amount = int.Parse(parts[1]);

                        Product product = register.GetProductByPLU(pluCode);
                        if (product != null)
                        {
                            for (int i = 0; i < amount; i++)
                            {
                                shoppingCart.Add(product);
                            }
                        }
                        else
                        {
                            consoleCenter.CenterText("Product not found.");
                            Console.ReadKey();
                        }
                    }
                    catch (Exception e)
                    {
                        consoleCenter.CenterText($"Error: {e.Message}");
                        consoleCenter.CenterText("Press any key to continue");
                        Console.ReadKey();
                    }
                }
                else
                {
                    IsPaymentCompleted = true;
                }
            }
            while (!IsPaymentCompleted);
            receipt.SaveReceipt(shoppingCart); //När betalningen är klart, kvittot sparas.

            consoleCenter.CenterText("Receipt saved and printed out.");
            consoleCenter.CenterText("Press any key to continue");
            Console.ReadKey();
        }
    }
}
