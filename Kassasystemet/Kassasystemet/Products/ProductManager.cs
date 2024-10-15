using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet.Register
{
    /// <summary>
    /// Manages a list of products.
    /// </summary>
    public class ProductManager
    {
        private List<Product> products = new List<Product>(); // Private pga Encapsulation!

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


