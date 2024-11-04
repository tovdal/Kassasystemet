using Kassasystemet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Admin.AdminAddInput
{
    public class AdminNameInput
    {
        public string InputName()
        {
            string productName;
            while (true)
            {
                Console.SetCursorPosition(60, 17);
                Console.WriteLine("Enter the name of the product.");
                Console.SetCursorPosition(60, 18);
                Console.Write(": ");
                productName = Console.ReadLine();
                if (productName == string.Empty)
                {
                    DisplayErrorMessage.ErrorMessage("The product must have a name. Erase and please enter again.");
                    continue;
                }
                return productName;
            }
        }
    }
}
