using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Campaign.CampaignInput
{
    public class CampaignPLUCodeInput(ProductManager productManager)
    {
        public int InputPLUCode()
        {
            int PLUCode;
            while (true)
            {
                Message.MessageString("Enter PLU code for the product.", 32, 12);
                Message.MessageString(": ", 32, 12);
                string PLUInput = Console.ReadLine();
                if (!int.TryParse(PLUInput, out PLUCode) || PLUInput.Length != 3)
                {
                    DisplayErrorMessage.ErrorMessage("invalid PLU. Erase and please enter a valid 3-digit number");
                    continue;
                }
                if (!productManager.IsPLUTaken(PLUCode))
                {
                    DisplayErrorMessage.ErrorMessage("PLU does not exist. Erase and please enter a valid PLU.");
                    continue;
                }
                return PLUCode;
            }
        }
    }
}
