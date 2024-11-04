using Kassasystemet.Admin.AdminAddInput;
using Kassasystemet.Admin.Display;
using Kassasystemet.Customer;
using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminAddProduct
    {
        public void SaveNewProductToFile(ProductManager productManager, string filePath)
        {
            var addProductBorder = new AdminDisplayBorder();
            var availiableProductsDisplay = new AvailableProductsDisplay();
            var inputPLU = new AdminPLUInput(productManager);
            var inputName = new AdminNameInput();
            var inputPrice = new AdminPriceInput();
            var inputUnit = new AdminUnitInput();

            bool IsValidInput = false;
            while (!IsValidInput)
            {
                Console.Clear();
                addProductBorder.ProductBorder();
                availiableProductsDisplay.DisplayAvailableProducts(productManager);
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Message.MessageString("-:Add new product:-", 75, 7);
                    Console.ForegroundColor = ConsoleColor.Gray;

                    int PLUCode = inputPLU.InputPLUCode();
                    string productName = inputName.InputName();
                    decimal price = inputPrice.InputPrice();
                    UnitType unit = inputUnit.inputUnit();

                    Product product = new Product(PLUCode, productName, price, unit);
                    productManager.AddProduct(product, filePath);

                    DisplaySuccessMessage.SuccessMessage("Product had been added successfully.");
                    IsValidInput = true;

                }
                catch (Exception ex)
                {
                    DisplayErrorMessage.ErrorMessage($"An unexpected error occurred: {ex.Message}");
                }
            }
        }
    }
}
