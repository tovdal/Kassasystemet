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
            var availiableProductsDisplay = new AvailableProductsDisplay();
            var addProductBorder = new AdminDisplayBorder();

            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.Clear();
                addProductBorder.ProductBorder();
                availiableProductsDisplay.DisplayAvailableProducts(productManager);

                Console.ForegroundColor = ConsoleColor.Red;
                Message.MessageString("-:Change product price:-",72, 7);
                Console.ForegroundColor = ConsoleColor.Gray;

                Product productToChange = adminPLUFinder.FindPLUCode(productManager);
                if (productToChange == null)
                {
                    DisplayErrorMessage.ErrorMessage("Product not found.");
                    continue;
                }

                Message.MessageString($"Current Price: {productToChange.Price}", 52, 17);
                Message.MessageString("Enter new price.", 52, 18);
                Message.MessageString(": ",52, 19);

                string newPriceString = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newPriceString) && decimal.TryParse(newPriceString, out decimal newPrice))
                {
                    productToChange.Price = newPrice;
                    DisplaySuccessMessage.SuccessMessage("Product price updated successfully.");
                    break;
                }
                else if (string.IsNullOrWhiteSpace(newPriceString))
                {
                    DisplayErrorMessage.ErrorMessage("No update to price was made.");
                }
                else
                {
                    DisplayErrorMessage.ErrorMessage("Invalid price entered. Try again.");
                }
            }
        }
    }
}