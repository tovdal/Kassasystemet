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
            Console.Clear();
            Console.WriteLine("\n\t\t ______________________________");
            Console.WriteLine("\t\t|Available Products:");
            foreach (var product in productManager.GetProducts())
            {
                Console.WriteLine($"\t\t|PLU: {product.PLUCode} - {product.ProductName} - {product.Unit}");
            }
        }
    }
}
