using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminUpdateProducts
    {
        public Product FindPLUCode(ProductManager productManager)
        {
            int PLUCode = 0;
            Console.WriteLine("Enter the PLUCode of the product you want to change.");
            try
            {
                PLUCode = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a valid PLU number");
            }

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
    }
}
