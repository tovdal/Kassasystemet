using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Admin.AdminAddInput
{
    public class AdminPLUInput(ProductManager productManager)
    {
        public int InputPLUCode()
        {
            int PLUCode;
            while (true)
            {
                string PLUInput = Console.ReadLine();
                if (!int.TryParse(PLUInput, out PLUCode) || PLUInput.Length != 3)
                {
                    DisplayErrorMessage.ErrorMessage("invalid PLU. Erase and please enter a valid 3-digit number");
                    continue;
                }
                if (productManager.IsPLUTaken(PLUCode))
                {
                    DisplayErrorMessage.ErrorMessage("This PLU code is already taken. Erase and please enter a different PLU.");
                    continue;
                }
                return PLUCode;
            }
        }
    }
}

