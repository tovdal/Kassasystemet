using Kassasystemet.Admin.Display;
using Kassasystemet.Customer;
using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminChangeProductName
    {
        public void ChangeNameProduct(ProductManager productManager, AdminPLUFinder adminPLUFinder)
        {
            Console.Clear();
            var availiableProductsDisplay = new AvailableProductsDisplay();
            var addProductBorder = new AdminDisplayBorder();

            addProductBorder.ProductBorder();
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

            Console.SetCursorPosition(52, 17);
            Console.WriteLine($"Current product Name: {productToChange.ProductName}");
            Console.SetCursorPosition(52, 18);
            Console.WriteLine("Enter new name (or press 'enter key' to keep current)");
            Console.SetCursorPosition(52, 19);
            Console.Write(": ");

            string newProductName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newProductName))
            {
                productToChange.ProductName = newProductName;
                DisplaySuccessMessage.SuccessMessage("Product name updated successfully.");
            }
        }
    }
}
