using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet
{
    internal class CashRegister
    {
        private Dictionary<int, Product> products = new Dictionary<int, Product>();
        private List<Product> cart = new List<Product>();


        public CashRegister(string filePath) 
        { 
            LoadProducts(filePath);
        }

        private void LoadProducts(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] strings = File.ReadAllLines(filePath);
                foreach (string s in strings)
                {
                    string[] parts = s.Split(' ');
                    int pluCode = int.Parse(parts[0]);
                    string productName = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    UnitType unit = (UnitType)Enum.Parse(typeof(UnitType), parts[3]);

                    products[pluCode] = new Product(pluCode, productName, price, unit);
                }
            }
            else
            {
                Console.WriteLine("Could not fine the wares file...");
            }
        }














    }
}
