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

            bool IsValidInput = false;
            while (!IsValidInput)
            {
                Console.Clear();
                addProductBorder.ProductBorder();
                availiableProductsDisplay.DisplayAvailableProducts(productManager);
                try
                {
                    Console.SetCursorPosition(75, 7);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-:Add new product:-");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.SetCursorPosition(60, 15);
                    Console.WriteLine("Enter the PLU of the product: ");
                    Console.SetCursorPosition(60, 16);
                    Console.Write(": ");
                    string PLUInput = Console.ReadLine();
                    if (!int.TryParse(PLUInput, out int PLUCode) || PLUInput.Length != 3)
                    {
                        DisplayErrorMessage.ErrorMessage("invalid PLU. Please enter a valid 3-digit number");
                        continue;
                    }
                    if (productManager.IsPLUTaken(PLUCode))
                    {
                        DisplayErrorMessage.ErrorMessage("This PLU code is already taken. Please enter a different PLU.");
                        continue;
                    }

                    Console.SetCursorPosition(60, 17);
                    Console.WriteLine("Enter the name of the product: ");
                    Console.SetCursorPosition(60, 18);
                    Console.Write(": ");
                    string productName = Console.ReadLine();

                    Console.SetCursorPosition(60, 19);
                    Console.WriteLine("Enter the price.");
                    Console.SetCursorPosition(60, 20);
                    Console.Write(": ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        DisplayErrorMessage.ErrorMessage("invalid price. Please enter a valid number.");
                        continue;
                    }

                    Console.SetCursorPosition(60, 21);
                    Console.Write("Is the product in 'kg' or 'pc'?");
                    Console.SetCursorPosition(60, 22);
                    Console.Write(": ");
                    string unitInput = Console.ReadLine();
                    if (!Enum.TryParse(unitInput, true ,out UnitType unit) || !Enum.IsDefined(typeof(UnitType), unit)) //https://zetcode.com/csharp/enum/
                    {
                        DisplayErrorMessage.ErrorMessage("Invalid unit type. Please enter either 'kg' or 'pc'.");
                        continue;
                    }

                    Product product = new Product(PLUCode, productName, price, unit);
                    productManager.AddProduct(product, filePath);

                    DisplaySuccessMessage.SuccessMessage("Product added successfully.");
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
