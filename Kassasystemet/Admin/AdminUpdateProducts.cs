using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminUpdateProducts
    {
        public void ChangeProductName(ProductManager productManager, AdminPLUFinder adminPLUFinder)
        {
            Product productToChange = adminPLUFinder.FindPLUCode(productManager);
            if (productToChange == null)
            {
                return;

            }
            Console.WriteLine($"Current product Name: {productToChange.ProductName}");
            Console.WriteLine($"Enter new Name: (or press enter if you whant to keep current name):");
            string newProductName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newProductName))
            {
                productToChange.ProductName = newProductName;
                Console.WriteLine("Product name updated successfully.");
            }
        }
        public void ChangeProductPrice(ProductManager productManager, AdminPLUFinder adminPLUFinder)
        {
            Product productToChange = adminPLUFinder.FindPLUCode(productManager);
            if (productToChange == null)
            {
                return;
            }

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
