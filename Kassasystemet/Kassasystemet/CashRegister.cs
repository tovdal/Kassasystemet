using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet
{
    // Ansvarar för att hantera produkter, kundvagnar och alla betalnings- och kvittofunktioner.
    public class CashRegister
    {
        private Dictionary<int, Product> products = new Dictionary<int, Product>();
        private List<CartItem> cartItems = new List<CartItem>();
        private string filePath;

        public CashRegister(string filePath)
        {
            this.filePath = filePath;
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
                        continue;
                    }

                    int pluCode = int.Parse(parts[0]);
                    string productName = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    UnitType unit = (UnitType)Enum.Parse(typeof(UnitType), parts[3]);

                    products[pluCode] = new Product(pluCode, productName, price, unit);
                }
            }
            else
            {
                Console.WriteLine("Could not find the wares file.");
            }
        }
        public void AddToCart(int pluCode, ushort quantity)
        {
            if (products.TryGetValue(pluCode, out Product product))
            {
                cartItems.Add(new CartItem(product, quantity));
                Console.WriteLine($"{quantity} x {product.ProductName}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public decimal GetTotalAmount()
        {
            decimal total = 0;
            foreach (var item in cartItems)
            {
                total += item.Product.Price * item.Quantity;
            }
            return total;

        }

        public void SaveReceipt(string filePath)
        {

        }
    }
}


