using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystemet.Kassasystemet.Register;

namespace Kassasystemet.Kassasystemet.Products
{
    public class ProductDataSeeder
    {
        //https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file

        // This class does not work right now.

        private readonly string _filePath; // måste ändra denna i framtiden?

        public ProductDataSeeder(string filePath)
        {
            _filePath = filePath;
        }

        public void SeedProducts()
        {
            var products = new List<Product>
            {
                new Product(100, "Milk", 12.95m, UnitType.pc),
                new Product(101, "Cream", 18.50m, UnitType.pc),
                new Product(102, "Cottage Cheese", 16.50m, UnitType.pc),
                new Product(203, "Dill", 22.90m, UnitType.kg),
                new Product(307, "Fish Sticks", 45.90m, UnitType.pc),
                new Product(308, "Salmon", 250.00m, UnitType.kg),
                new Product(401, "Minced Meat", 105.00m, UnitType.kg),
                new Product(402, "Meatballs", 55.95m, UnitType.pc),
                new Product(501, "Pork", 86.50m, UnitType.kg),
                new Product(601, "Candy", 88.8m, UnitType.kg)
            };

            SaveProductsToFile(products);
        }

        private void SaveProductsToFile(List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false)) //false är för att skriva över filen
            {
                foreach (Product product in products)
                {
                    writer.WriteLine($"{product.PLUCode} {product.ProductName} {product.Price} {product.Unit}");
                }
            }
        }
    }
}
