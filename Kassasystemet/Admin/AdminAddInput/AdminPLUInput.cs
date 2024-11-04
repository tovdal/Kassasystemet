using Kassasystemet.Messages;
using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Admin.AdminAddInput
{
    public class AdminPLUInput(ProductManager productManager)
    {
        public int InputPLUCode()
        {
            int PLUCode;
            while (true)
            {
                Console.SetCursorPosition(60, 15);
                Console.WriteLine("Enter the PLU of the product.");
                Console.SetCursorPosition(60, 16);
                Console.Write(": ");
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

