using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Kassasystemet.Kassasystemet
{
    class Program
    {
        static void Main(string[] args)
        {
            string productFilePath = "../../../Files/products.txt"; //Filvägen till produkterna
            CashRegister register = new CashRegister(productFilePath);
            bool IsRunning = true;

            while (IsRunning)
            {
                Console.Clear();
                Console.WriteLine("Cashier System 1.0\n");
                Console.WriteLine("[1] New Customer");
                Console.WriteLine("[2] Admin Tools");
                Console.WriteLine("[3] Exit\n");

                Console.WriteLine("Pick selection: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // hanterar kund
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
                        while(!IsPaymentCompleted);

                        break;
                    case "2":
                        // Admin verktyg? om jag kommer så långt,
                        break;
                    case "3":
                        IsRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                //Console.WriteLine("Cash Register System");

                //// Initialisera CashRegister och andra klasser
                //var cashRegister = new CashRegister("../../../Products.txt");

                //cashRegister.AddToCart(101, 2); // Exempel på PLU-kod och kvantitet
                //cashRegister.AddToCart(102, 3); // Exempel på PLU-kod och kvantitet
                //cashRegister.AddToCart(999, 1); // En ogiltig kod för att se felmeddelande

                //// Visa totalbeloppet
                //decimal total = cashRegister.GetTotalAmount();
                //Console.WriteLine($"Total amount in cart: {total:C}");
                //// Logik för användarinteraktion
            }
        }
    }
}
