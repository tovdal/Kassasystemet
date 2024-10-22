using Kassasystemet.Products;
using Kassasystemet.VisualChanges;

namespace Kassasystemet.Customer
{
    public class CustomerImput
    {
        public void HandleProductInput(ConsoleWriteLineCenter consoleCenter, ProductManager productManager, List<Product> shoppingCart, string input)
        {
            try
            {
                string[] parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    ShowErrorMessage("Please enter in the format: <PLU> <amount>");
                }
                int pluCode = int.Parse(parts[0]);
                int amount = int.Parse(parts[1]);

                Product product = productManager.GetProductByPLU(pluCode);
                if (product != null)
                {
                    for (int i = 0; i < amount; i++)
                    {
                        shoppingCart.Add(product);
                    }
                }
                else
                {
                    Console.ReadKey();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
        private static void ShowErrorMessage(string message)
        {
            Console.SetCursorPosition(80, Console.CursorTop + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.SetCursorPosition(86, Console.CursorTop + 1);
            Console.ReadKey();

        }
    }
}
