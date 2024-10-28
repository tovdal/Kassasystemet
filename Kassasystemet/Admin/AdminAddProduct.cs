using Kassasystemet.Admin.Display;
using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminAddProduct
    {
        public void SaveNewProductToFile(ProductManager productManager, string filePath)
        {
            var addProductBorder = new AdminAddProductDisplayBorder();

            bool IsValidInput = false;
            while (!IsValidInput)
            {
                Console.Clear();
                addProductBorder.AdminAddProductBorder();

                try
                {
                    Console.SetCursorPosition(95, 17);
                    // Color red
                    Console.WriteLine("Add new product");
                    // Normal color

                    Console.SetCursorPosition(78, 20);
                    Console.Write("Enter the PLU of the product: ");
                    string PLUInput = Console.ReadLine();
                    if (!int.TryParse(PLUInput, out int PLUCode) || PLUInput.Length !=3)
                    {
                        Console.SetCursorPosition(72, 29);
                        Console.WriteLine("invalid PLU. Please enter a valid 3-digit number");
                        Console.ReadKey();
                        continue;
                    }
                    if (productManager.IsPLUTaken(PLUCode))
                    {
                        Console.SetCursorPosition(72, 29);
                        Console.WriteLine("This PLU code is already taken. Please enter a different PLU.");
                        Console.ReadKey();
                        continue;
                    }

                    Console.SetCursorPosition(78, 21);
                    Console.Write("Enter the name of the product: ");
                    string productName = Console.ReadLine();

                    Console.SetCursorPosition(78, 22);
                    Console.Write("Enter the price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        Console.SetCursorPosition(72, 29);
                        Console.WriteLine("invalid price. Please enter a valid number.");
                        Console.ReadKey();
                        continue;
                    }

                    Console.SetCursorPosition(78, 23);
                    Console.Write("Is the product in kg or pc? (Enter 'kg' or 'pc')");
                    string unitInput = Console.ReadLine();
                    UnitType unit;
                    if (!Enum.TryParse(unitInput, true, out unit))
                    {
                        Console.SetCursorPosition(72, 29);
                        Console.WriteLine("Invalid unit type. Please enter either 'kg' or 'pc'.");
                        Console.ReadKey();
                        continue;
                    }

                    Product product = new Product(PLUCode, productName, price, unit);

                    productManager.AddProduct(product, filePath);

                    Console.SetCursorPosition(78, 24);
                    Console.WriteLine("Product added successfully.");
                    IsValidInput = true;
                    Console.ReadKey();
                }
                catch (ArgumentNullException e)
                {
                    Console.SetCursorPosition(72, 29);
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                catch (OverflowException e)
                {
                    Console.SetCursorPosition(72, 29);
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.SetCursorPosition(72, 29);
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }
    }
}
