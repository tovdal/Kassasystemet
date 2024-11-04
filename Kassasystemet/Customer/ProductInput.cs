using Kassasystemet.Messages;
using Kassasystemet.Products;
using Kassasystemet.VisualChanges;

namespace Kassasystemet.Customer
{
    public class ProductInput
    {
        public void HandleProductInput(CreateBorder createBorder, ProductManager productManager, List<Product> shoppingCart, string input)
        {
            try
            {
                string[] parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    DisplayErrorMessage.ErrorMessage("Please enter in the format: <PLU> <amount>");
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
            catch (OverflowException e)
            {
                DisplayErrorMessage.ErrorMessage(e.Message);
            }
            catch (FormatException e)
            {
                DisplayErrorMessage.ErrorMessage(e.Message);
            }
        }
    }
}
