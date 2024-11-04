using Kassasystemet.Admin.Display;
using Kassasystemet.Customer;
using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminChangeProductPrice
    {
        public void ChangePriceProduct(ProductManager productManager, AdminPLUFinder adminPLUFinder)
        {
            Console.Clear();
            var availiableProductsDisplay = new AvailableProductsDisplay();
            var addProductBorder = new AdminDisplayBorder();

            addProductBorder.ProductBorder();
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
                DisplaySuccessMessage.SuccessMessage("Product price updated successfully.");
            }
        }
    }
}
