﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet.Customer
{
    // Ansvarar för att hantera produkter, kundvagnar och alla betalnings- och kvittofunktioner.
    public class CashRegister
    {
        private List<Product> products = new List<Product>();

        public CashRegister(string filePath)
        {
            LoadProducts(filePath);
        }

        private void LoadProducts(string filePath)
        {
            // Läser in produkter från fil
            if (File.Exists(filePath))
            {
                string[] strings = File.ReadAllLines(filePath);
                foreach (string s in strings)
                {
                    string[] parts = s.Split(' ');

                    if (parts.Length < 4)
                    {
                        Console.WriteLine($"Ogiltig rad i filen: {strings}");
                        Console.ReadKey();
                        continue;
                    }

                    int pluCode = int.Parse(parts[0]);
                    string productName = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    UnitType unit = (UnitType)Enum.Parse(typeof(UnitType), parts[3]);

                    products.Add(new Product(pluCode, productName, price, unit));
                }
            }
            else
            {
                Console.WriteLine("Could not find the product file.");
            }
        }
        public Product GetProductByPLU(int pluCode)
        {
            foreach (var product in products)
            {
                if (product.PLUCode == pluCode)
                {
                    return product;
                }
            }
            return null; //ingen product hittades.

        }
    }
}


