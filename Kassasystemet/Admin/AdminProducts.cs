using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Admin
{
    public class AdminProducts
    {
        public Product FindPLUCode(ProductManager productManager)
        {
            Console.WriteLine("Enter the PLUCode of the product you want to change.");
            int PLUCode = Convert.ToInt32(Console.ReadLine());

            Product productToChange = productManager.GetProductByPLU(PLUCode);
            if (productToChange == null)
            {
                Console.WriteLine("Product not found");
                return null;
            }
            return productToChange;
        }
        public void ChangeProductName(ProductManager productManager)
        {
            Product productToChange = FindPLUCode(productManager);
            if (productToChange == null) return;

            Console.WriteLine($"Current product Name: {productToChange.ProductName}");
            Console.WriteLine($"Enter new Name: (or press enter if you whant to keep current name):");
            string newProductName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newProductName))
            {
                productToChange.ProductName = newProductName;
                Console.WriteLine("Product name updated successfully.");
            }
        }
        public void ChangeProductPrice(ProductManager productManager)
        {
            Product productToChange = FindPLUCode(productManager);
            if (productToChange == null) return;

            Console.WriteLine($"Current Price: {productToChange.Price}");
            Console.WriteLine($"Enter new Price (or press enter if you whant to keep current price):");
            string newPriceString = Console.ReadLine();

            if (decimal.TryParse(newPriceString, out decimal newPrice))
            {
                productToChange.Price = newPrice;
                Console.WriteLine("Product price updated successfully.");
            }
        }
        public void SaveNewProductToFile(ProductManager productManager)
        {
            using (StreamWriter writeNewProduct = new StreamWriter(filepath))
            {
                foreach (Product product in products)
                {
                    writeNewProduct.WriteLine($"{product.PLUCode} {product.ProductName} {product.Price} {product.Unit}");
                }
            }
            Console.WriteLine("The new product has ben saved successfully!");
        }

    }
}
