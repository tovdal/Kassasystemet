using Kassasystemet.Admin.Display;
using Kassasystemet.Customer;
using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminUpdateProducts
    {

        public void ChangeProductName(ProductManager productManager, AdminPLUFinder adminPLUFinder)
        {
            Console.Clear();
            var availiableProductsDisplay = new AvailableProductsDisplay();
            var addProductBorder = new AdminAddProductDisplayBorder();
            addProductBorder.AdminAddProductBorder();
            availiableProductsDisplay.DisplayAvailableProducts(productManager);

            Console.SetCursorPosition(72, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-:Change product name:-");
            Console.ForegroundColor = ConsoleColor.Gray;

            Product productToChange = adminPLUFinder.FindPLUCode(productManager);
            if (productToChange == null)
            {
                return;

            }
            Console.SetCursorPosition(52, 16);
            Console.WriteLine($"Current product Name: {productToChange.ProductName}");
            Console.SetCursorPosition(52, 17);
            Console.WriteLine($"Enter new Name");
            Console.SetCursorPosition(52, 18);
            Console.Write("(or press enter if you whant to keep current name):");
            string newProductName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newProductName))
            {
                productToChange.ProductName = newProductName;
                Console.SetCursorPosition(52, 19);
                Console.WriteLine("Product name updated successfully.");
            }
        }
        public void ChangeProductPrice(ProductManager productManager, AdminPLUFinder adminPLUFinder)
        {
            Console.Clear();
            var availiableProductsDisplay = new AvailableProductsDisplay();
            var addProductBorder = new AdminAddProductDisplayBorder();
            addProductBorder.AdminAddProductBorder();
            availiableProductsDisplay.DisplayAvailableProducts(productManager);

            Console.SetCursorPosition(72, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-:Change product price:-");
            Console.ForegroundColor = ConsoleColor.Gray;

            Product productToChange = adminPLUFinder.FindPLUCode(productManager);
            if (productToChange == null)
            {
                return;
            }

            Console.SetCursorPosition(52, 16);
            Console.WriteLine($"Current Price: {productToChange.Price}");
            Console.SetCursorPosition(52, 17);
            Console.WriteLine("Enter new Price");
            Console.SetCursorPosition(52, 18);
            Console.Write("(or press enter if you whant to keep current price):");
            string newPriceString = Console.ReadLine();

            if (decimal.TryParse(newPriceString, out decimal newPrice))
            {
                productToChange.Price = newPrice;
                Console.SetCursorPosition(52, 19);
                Console.WriteLine("Product price updated successfully.");
            }
        }
    }
}
