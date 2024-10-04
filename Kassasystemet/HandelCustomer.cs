using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet
{
    internal class HandelCustomer
    {
        private CashRegister CashRegister;
        public HandelCustomer()
        {
            CashRegister cashRegister1 = new CashRegister("../../../Files/{receipt} Names -{TodayDate}.txt"); // ??????????????????????????
        }

        static void HandleNewCustomer(CashRegister cashRegister)
        {
            List<CartItem> shoppingCart = new List<CartItem>();
            Receipt receipt = new Receipt();
            string userCommand;

            do
            {
                Console.Clear();
                Console.WriteLine("CASH REGISTER");
                Console.WriteLine($"RECEIPT      " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("\n");

                foreach (var item in shoppingCart)
                {
                    Console.WriteLine($"{item.Product.ProductName} - {item.Product.Price:C} * {item.Quantity} = {(item.Quantity * item.Product.Price):C}");
                }

                Console.WriteLine($"Total: {receipt.TotalAmount:C}");
                Console.WriteLine("<PLU code> <amount> PAY");
                Console.Write("Command: ");

                userCommand = Console.ReadLine();
                string[] commands = userCommand.Split(' ');

                if (commands[0].ToUpper() != "PAY")
                {
                    int pluCode = int.Parse(commands[0]);
                    int quantity = int.Parse(commands[1]);

                    if (cashRegister.TryGetProduct(pluCode, out Product product))
                    {
                        // Kolla om produkten redan finns i kundvagnen
                        var existingItem = shoppingCart.FirstOrDefault(i => i.Product.PLUCode == pluCode);
                        if (existingItem != null)
                        {
                            existingItem.Quantity += quantity; // Öka kvantiteten
                        }
                        else
                        {
                            shoppingCart.Add(new CartItem(product, quantity)); // Lägg till ny produkt
                        }

                        receipt.AddProduct(product, quantity);
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                }

            } while (userCommand.ToUpper() != "PAY");

            // Skriv ut och spara kvittot
            PrintAndSaveReceipt(receipt);
        }

        private void PrintAndSaveReceipt(Receipt receipt)
        {
            receipt.PrintReceipt(); // Skriv ut kvittot
            string filePath = $"../../../Receipts/Receipt_{DateTime.Now:yyyyMMdd_HHmmss}.txt"; // Definiera filvägen
            receipt.SaveReceipt(filePath); // Spara kvittot i filen
            Console.WriteLine($"Kvitto sparat på: {filePath}"); // Meddela användaren om att kvittot har sparats
        }
    }
    // Kvittot måst skrivas ut här?
    //var todaysDate = DateTime.Now.ToShortDateString();
}
