using Kassasystemet.Products;
using Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Customer
{
    public class CustomerImput
    {
        public static void HandleProductInput(ConsoleWriteLineCenter consoleCenter, ProductManager productManager, List<Product> shoppingCart, string input)
        {
            try
            {
                string[] parts = input.Split(' ');
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
                    consoleCenter.CenterText("Product not found.");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                consoleCenter.CenterText($"Error: {e.Message}");
                consoleCenter.CenterText("Press any key to continue");
                Console.ReadKey();

            }
        }
    }
}
