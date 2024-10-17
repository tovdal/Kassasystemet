using Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Products
{
    /// <summary>
    /// Manages a list of products.
    /// </summary>
    public class ProductManager
    {
        private List<Product> products = new List<Product>();
        private ConsoleWriteLineCenter consoleCenter;


        public ProductManager(IProductLoader productloader, string filePath, ConsoleWriteLineCenter consoleCenter)
        {
            products = productloader.LoadProducts(filePath);
            this.consoleCenter = consoleCenter;
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
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            consoleCenter.CenterText($"Product with {pluCode} could not be found."); // This needs to be centerd.
            Console.ForegroundColor = ConsoleColor.Gray;
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


