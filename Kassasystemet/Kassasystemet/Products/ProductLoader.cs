using Kassasystemet.Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet.Register
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
                    string[] parts = s.Split(' ');

                    if (parts.Length < 4)
                    {
                        Console.WriteLine($"Invalid line in file: {s}");
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

            return products;
        }
    }
}
