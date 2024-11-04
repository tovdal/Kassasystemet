using Kassasystemet.Messages;
using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Campaign.CampaignAddInput
{
    public class CampaignPLUCodeInput(ProductManager productManager)
    {
        public int InputPLUCode()
        {
            int PLUCode;
            while (true)
            {
                Console.SetCursorPosition(32, 12);
                Console.WriteLine("Enter PLU code for the product.");
                Console.SetCursorPosition(32, 13);
                Console.Write(": ");
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
