using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet.Customer
{
    /// <summary>
    /// Cash register system that loads and manages a list of products.
    /// </summary>
    public class CashRegisterSystem
    {
        private List<Product> products = new List<Product>(); // Private pga Encapsulation!

        public CashRegisterSystem(string filePath)
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
                        Console.WriteLine($"Ogiltig rad i filen: {s}");
                        Console.ReadKey();
                        continue;
                    }

                    int pluCode = int.Parse(parts[0]);
                    string productName = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    UnitType unit = (UnitType)Enum.Parse(typeof(UnitType), parts[3]);

                    Product product = new Product(pluCode, productName, price, unit);
                    products.Add(product);
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
            Console.WriteLine($"Produkten med PLU {pluCode} hittades inte.");
            return null; //ingen product hittades.

        }

        /// <summary>
        /// Returns products in the list.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            return products;
        }
    }
}


