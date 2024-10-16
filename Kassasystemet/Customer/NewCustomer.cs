﻿using Kassasystemet.VisualChanges;
using Kassasystemet.Products;
using Kassasystemet.Receipts;


namespace Kassasystemet.Customer
{
    public class NewCustomer
    {

        public void StartNewCustormer()
        {
            var calculateReceipt = new CalculateReceipt();
            var salesReceipt = new PrintSalesReceipt();
            var latestReceiptNumber = new LatestReceiptNumber();
            var consoleCenter = new ConsoleWriteLineCenter();

            // hanterar kund
            string productFilePath = "../../../Files/products.txt"; //Filvägen till produkterna

            IProductLoader productLoader = new ProductLoader();
            ProductManager productManager = new ProductManager(productLoader, productFilePath, consoleCenter);

            List<Product> shoppingCart = new List<Product>();

            string input;
            bool IsPaymentCompleted = false;

            do
            {
                DisplayAvailableProducts(productManager);
                DisplayReceipt(calculateReceipt, consoleCenter, shoppingCart);

                input = Console.ReadLine();

                if (input.ToUpper() != "PAY")
                {
                    HandleProductInput(consoleCenter, productManager, shoppingCart, input);
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

        private static void DisplayReceipt(CalculateReceipt calculateReceipt, ConsoleWriteLineCenter consoleCenter, List<Product> shoppingCart)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            consoleCenter.CenterText("Cash Register - New Customer\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            consoleCenter.CenterText("─────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            consoleCenter.CenterText($"Receipt     {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // visa shoppingCart varorna i 
            foreach (var products in shoppingCart)
            {
                consoleCenter.CenterText($"{products.ProductName} - {products.Price:C}");
            }
            consoleCenter.CenterText("");
            consoleCenter.CenterText($"Total:                 {calculateReceipt.CalculateTotal(shoppingCart):C}");
            consoleCenter.CenterText($"Taxes:                 {calculateReceipt.CalculateTax(shoppingCart):C}");
            consoleCenter.CenterText("                           ");
            Console.ForegroundColor = ConsoleColor.Green;
            consoleCenter.CenterText("Commands: <PLU> <amount> or type 'PAY' to complete");
            Console.ForegroundColor = ConsoleColor.Gray;
            consoleCenter.CenterText("─────────────────────────────────────────────────────");
            consoleCenter.CenterTextShort("Command: ");
        }

        private static void HandleProductInput(ConsoleWriteLineCenter consoleCenter, ProductManager productManager, List<Product> shoppingCart, string input)
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

        private static void DisplayAvailableProducts(ProductManager productManager)
        {
            Console.Clear();
            Console.WriteLine("\n\t\t ______________________________");
            Console.WriteLine("\t\t|Available Products:");
            foreach (var product in productManager.GetProducts())
            {
                Console.WriteLine($"\t\t|PLU: {product.PLUCode} - {product.ProductName} - {product.Unit}");
            }
        }
    }
}
