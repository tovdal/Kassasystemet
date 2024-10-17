using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Customer
{
    public class DisplayProducts
    {
        public static void DisplayAvailableProducts(ProductManager productManager)
        {
            Console.SetCursorPosition(119, 9);
            Console.WriteLine("Available Products:");


            int currentRow = 12;

            foreach (var product in productManager.GetProducts())
            {
                Console.SetCursorPosition(119, currentRow);
                Console.WriteLine($"PLU: {product.PLUCode} - {product.ProductName} - {product.Unit}");
                currentRow++;
            }
        }
    }
}
