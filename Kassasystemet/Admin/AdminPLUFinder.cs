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
            Console.WriteLine("Enter the PLUCode of the product you want to change");
            Console.SetCursorPosition(52, 16);
            Console.Write(": ");
            try
            {
                PLUCode = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                DisplayErrorMessage.ErrorMessage("You must enter a valid PLU number");
                return null;
            }
            catch (OverflowException)
            {
                DisplayErrorMessage.ErrorMessage("Invalid PLU. Please enter a valid 3 - digit number");
                return null;
            }

            Product productToChange = productManager.GetProductByPLU(PLUCode);
            if (productToChange == null)
            {
                DisplayErrorMessage.ErrorMessage("Invalid PLU. Please enter a valid 3 - digit number");
                return null;
            }
            return productToChange;
        }
    }
}
