using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminAddProduct
    {
        public void SaveNewProductToFile(ProductManager productManager, string filePath)
        {
            bool IsValidInput = false;
            while (!IsValidInput)
            {
                try
                {
                    Console.WriteLine("Enter the PLU of the product: ");
                    string PLUInput = Console.ReadLine();
                    if (!int.TryParse(PLUInput, out int PLUCode) || PLUInput.Length !=3)
                    {
                        Console.WriteLine("invalid PLU. Please enter a valid 3-digit number");
                        Console.ReadKey();
                        continue;
                    }
                    if (productManager.IsPLUTaken(PLUCode))
                    {
                        Console.WriteLine("This PLU code is already taken. Please enter a different PLU.");
                        Console.ReadKey();
                        continue;
                    }
                    Console.WriteLine("Enter the name of the product: ");
                    string productName = Console.ReadLine();

                    Console.WriteLine("Enter the price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        Console.WriteLine("invalid price. Please enter a valid number.");
                        Console.ReadKey();
                        continue;
                    }
                    Console.WriteLine("Is the product in kg or pc? (Enter 'kg' or 'pc')");
                    string unitInput = Console.ReadLine();
                    UnitType unit;

                    if (!Enum.TryParse(unitInput, true, out unit))
                    {
                        Console.WriteLine("Invalid unit type. Please enter either 'kg' or 'pc'.");
                        Console.ReadKey();
                        continue;
                    }

                    Product product = new Product(PLUCode, productName, price, unit);

                    productManager.AddProduct(product, filePath);

                    Console.WriteLine("Product added successfully.");
                    IsValidInput = true;
                    Console.ReadKey();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }
    }
}
