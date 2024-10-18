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

        public ProductManager(IProductLoader productloader, string filePath)
        {
            products = productloader.LoadProducts(filePath);
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
            consoleCenter.CenterText($"Product with {pluCode} could not be found.");
            Console.ForegroundColor = ConsoleColor.Gray;
            return null; //ingen product hittades.

        }

        public void AddProduct(Product newProduct, string filePath)
        {
            products.Add(newProduct);
            SaveNewProductToFile(filePath); // Save changes to file after adding a product
        }

        public void SaveNewProductToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.PLUCode}:{product.ProductName}:{product.Price}:{product.Unit}");
                }
            }
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


