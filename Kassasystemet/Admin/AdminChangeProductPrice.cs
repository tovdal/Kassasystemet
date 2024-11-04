using Kassasystemet.Admin.Display;
using Kassasystemet.Campaign;
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

            Console.SetCursorPosition(52, 17);
            Console.WriteLine($"Current Price: {productToChange.Price}");
            Console.SetCursorPosition(52, 18);
            Console.WriteLine("Enter new Price (or press 'enter key' to keep current)");
            Console.SetCursorPosition(52, 19);
            Console.Write(": ");
            string newPriceString = Console.ReadLine();

            if (decimal.TryParse(newPriceString, out decimal newPrice))
            {
                productToChange.Price = newPrice;
                DisplaySuccessMessage.SuccessMessage("Product price has updated successfully.");
            }
            if (string.IsNullOrWhiteSpace(newPriceString))
            {
                DisplayErrorMessage.ErrorMessage("No update to price was made.");
            }

        }
    }
}
