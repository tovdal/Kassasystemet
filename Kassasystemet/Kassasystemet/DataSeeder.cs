using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet
{
    public class DataSeeder
    {
        //https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file

        private readonly string _filePath; // måste ändra denna i framtiden?

        public DataSeeder(string filePath)
        {
            _filePath = filePath;
        }

        public void SeedProducts()
        {
            var products = new List<Product>
            {
                new Product(1000, "Milk", 12.95m, UnitType.pc),
                new Product(1001, "Cream", 18.50m, UnitType.pc),
                new Product(1002, "Cottage Cheese", 16.50m, UnitType.pc),
                new Product(2003, "Dill", 22.90m, UnitType.kg),
                new Product(3007, "Fish Sticks", 45.90m, UnitType.pc),
                new Product(3008, "Salmon", 250.00m, UnitType.kg),
                new Product(4001, "Minced Meat", 105.00m, UnitType.kg),
                new Product(4002, "Meatballs", 55.95m, UnitType.pc),
                new Product(5001, "Pork", 86.50m, UnitType.kg)
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
