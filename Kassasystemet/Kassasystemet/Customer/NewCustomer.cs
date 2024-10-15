using Kassasystemet.Kassasystemet.Receipt;
using Kassasystemet.Kassasystemet.Register;
using Kassasystemet.Kassasystemet.VisualChanges;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kassasystemet.Kassasystemet.Customer
{
    public class NewCustomer
    {
        public void StartNewCustormer(CalculateReceipt calculateReceipt, SalesReceipt salesReceipt, ConsoleCenter consoleCenter)
        {
            // hanterar kund
            string productFilePath = "../../../Files/products.txt"; //Filvägen till produkterna

            IProductLoader productLoader = new ProductLoader();
            ProductManager productManager = new ProductManager(productLoader, productFilePath);

            List<Product> shoppingCart = new List<Product>();

            string input;
            bool IsPaymentCompleted = false;

            do
            {
                Console.Clear();

                // Skriver ut alla producter med PLU och namn som finns med i listan.
                Console.WriteLine("Available Products:");
                foreach (var product in productManager.GetProducts())
                {
                    Console.WriteLine($"PLU: {product.PLUCode} - {product.ProductName} - {product.Unit}");
                }

                int lines = 15;
                consoleCenter.SetCursorToMiddle(lines);

                consoleCenter.CenterText("───────────────────────────────────");
                Console.ForegroundColor = ConsoleColor.White;
                consoleCenter.CenterText("Cash Register - New Customer\n");
                Console.ForegroundColor = ConsoleColor.Green;
                consoleCenter.CenterText($"Receipt     {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                // visa shoppingCart varorna i 
                foreach (var products in shoppingCart)
                {
                    consoleCenter.CenterText($"{products.ProductName} - {products.Price:C}");
                }

                consoleCenter.CenterText($"Total:                 {calculateReceipt.CalculateTotal(shoppingCart):C}");
                consoleCenter.CenterText("Command:                        ");
                Console.ForegroundColor = ConsoleColor.Green;
                consoleCenter.CenterText("<PLU> <amount> or type 'PAY' to complete");
                Console.ForegroundColor = ConsoleColor.Gray;
                consoleCenter.CenterText("───────────────────────────────────");

                input = Console.ReadLine();

                if (input.ToUpper() != "PAY")
                {
                    try
                    {
                        string[] parts = input.Split(' ');
                        int pluCode = int.Parse(parts[0]);
                        int amount = int.Parse(parts[1]);

                        Product product = productManager.GetProductByPLU(pluCode);
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
            salesReceipt.SaveReceipt(shoppingCart, calculateReceipt); //När betalningen är klart, kvittot sparas.

            consoleCenter.CenterText("Receipt saved and printed out.");
            consoleCenter.CenterText("Press any key to continue");
            Console.ReadKey();
        }
    }
}
