using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminPLUFinder
    {
        public Product FindPLUCode(ProductManager productManager)
        {
            int PLUCode = 0;
            Message.MessageString("Enter the PLUCode of the product you want to change", 52, 15);
            Message.MessageString(": ", 52, 16);
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
