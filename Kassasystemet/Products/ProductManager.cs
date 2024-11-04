using Kassasystemet.Messages;
using Kassasystemet.Products.Interface;

namespace Kassasystemet.Products
{
    /// <summary>
    /// Manages a list of products.
    /// </summary>
    public class ProductManager
    {
        private IProductLoader _productLoader;
        private List<Product> products = new List<Product>();

        public ProductManager(IProductLoader productLoader, string filePath)
        {
            _productLoader = productLoader;
            products = productLoader.LoadProducts(filePath);
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
            return null;
        }

        public void AddProduct(Product newProduct, string filePath)
        {
            products.Add(newProduct);
            SaveNewProductToFile(filePath, newProduct);
        }

        public decimal? GetProductPrice(int pluCode) 
        {
            foreach (var product in products)
            {
                if (product.PLUCode == pluCode)
                {
                    return product.Price;
                }
            }
            return null; //'?' can return null- not found.
        }

        /// <summary>
        /// If PLU Code is taken it will retun true or false
        /// </summary>
        /// <param name="PLUCode"></param>
        /// <returns></returns>
        public bool IsPLUTaken(int PLUCode)
        {
            foreach (var product in products)
            {
                if (product.PLUCode == PLUCode)
                {
                    return true;
                }
            }
            return false;
        }

        public void SaveNewProductToFile(string filePath, Product newProduct)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine($"{newProduct.PLUCode}:{newProduct.ProductName}:{newProduct.Price}:{newProduct.Unit}");
            }
        }
        /// <summary>
        /// The return is an sorted original list of the PLU Products in lowest to highest.
        /// https://www.webdevtutor.net/blog/c-sharp-lambda-on-list
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            products.Sort((product1, product2) => product1.PLUCode.CompareTo(product2.PLUCode));
            return products;
        }
    }
}