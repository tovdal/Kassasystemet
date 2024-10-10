using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
            List<Product> shoppingCart = new List<Product>();
            string input;
            bool IsPaymentCompleted = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Cash Registre");
                Console.WriteLine($"Receipt     {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

                foreach (var products in shoppingCart)
                {
                    Console.WriteLine($"{products.ProductName} - {products.Price:C}");
                }

                Console.WriteLine($"Total: {Receipt.CalculateTotal(shoppingCart):C}");
                Console.WriteLine("<PLU code> or type 'PAY' to complete");
                Console.WriteLine("Command: ");
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
                            Console.WriteLine("Product not found.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }
                else
                {
                    IsPaymentCompleted = true;
                }
            }
            while (!IsPaymentCompleted);
            Receipt.SaveReceipt(shoppingCart); //När betalningen är klart, kvittot sparas.
        }
    }
}
