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
            var availiableProductsDisplay = new AvailableProductsDisplay();
            var addProductBorder = new AdminDisplayBorder();

            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.Clear();
                addProductBorder.ProductBorder();
                availiableProductsDisplay.DisplayAvailableProducts(productManager);
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Message.MessageString("-:Change product name:-",72, 7);
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Product productToChange = adminPLUFinder.FindPLUCode(productManager);
                    if (productToChange == null)
                    {
                        continue;
                    }

                    Message.MessageString($"Current product Name: {productToChange.ProductName}", 52, 17);
                    Message.MessageString("Enter new name.", 52, 18);
                    Message.MessageString(": ",52, 19);

                    string newProductName = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(newProductName))
                    {
                        productToChange.ProductName = newProductName;
                        DisplaySuccessMessage.SuccessMessage("Product name updated successfully.");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(newProductName))
                    {
                        DisplayErrorMessage.ErrorMessage("No update to name was made.");
                    }
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage.ErrorMessage($"An unexpected error occurred: {ex.Message}");
                }
            }
        }
    }
}
