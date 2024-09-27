using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet
{
    internal class Receipt
    {

        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalAmount { get; set; }


        public void AddProduct(Product product, int quantity)
        {
            Products.Add(product);
            TotalAmount += product.Price * quantity;
        }

        public void PrintReceipt()
        {
            Console.WriteLine("Receipt:");
            foreach (Product product in Products)
            {
                Console.WriteLine($"{product.ProductName} - {product.Price:C}"); // här hittade jag :C https://dzone.com/articles/c-string-format-examples
            }
            Console.WriteLine($"Total: {TotalAmount}");
        }

        public void SaveReceipt(string filePath)
        {
            using (StreamWriter myStream = new StreamWriter($"../../../Files/{receipt} Names -{TodayDate}.txt", append: false))
            {
                foreach (string name in names)
                {
                    myStream.WriteLine(name);
                }
            }

        }
    }
}
