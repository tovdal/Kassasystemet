using Kassasystemet.Products.Interface;
using Kassasystemet.VisualChanges;

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

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(83, 38);
            Console.WriteLine("Product with that PLU could not be found.");
            Console.ResetColor();
            Console.ReadKey();
            return null;
        }

        public void AddProduct(Product newProduct, string filePath)
        {
            products.Add(newProduct);
            SaveNewProductToFile(filePath, newProduct);
        }


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

        public List<Product> GetProducts()
        {
            products.Sort((product1, product2) => product1.PLUCode.CompareTo(product2.PLUCode)); // Lambda !!!
            //https://www.webdevtutor.net/blog/c-sharp-lambda-on-list
            return products;
        }

    }
}


