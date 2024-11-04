using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminPLUFinder
    {
        public Product FindPLUCode(ProductManager productManager)
        {
            int PLUCode = 0;
            Console.SetCursorPosition(52, 15);
            Console.Write("Enter the PLUCode of the product you want to change:");
            try
            {
                PLUCode = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                DisplayErrorMessage.ErrorMessage("You must enter a valid PLU number");
            }

            Product productToChange = productManager.GetProductByPLU(PLUCode);
            if (productToChange == null)
            {
                DisplayErrorMessage.ErrorMessage("Product not found");
                return null;
            }
            return productToChange;
        }
    }
}
