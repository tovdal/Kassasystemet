﻿using Kassasystemet.Products.Interface;

namespace Kassasystemet.Products
{
    public class ProductLoader : IProductLoader
    {
        public List<Product> LoadProducts(string filePath)
        {
            List<Product> products = new List<Product>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string s in lines)
                {
                    string[] parts = s.Split(':');

                    if (parts.Length < 4)
                    {
                        Console.WriteLine($"\nInvalid line in file: {s}");
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
                Console.WriteLine("\nCould not find the product file.");
            }

            return products;
        }
    }
}
