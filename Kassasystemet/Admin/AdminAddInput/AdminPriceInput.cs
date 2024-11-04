using Kassasystemet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Admin.AdminAddInput
{
    public class AdminPriceInput
    {
        public decimal InputPrice()
        {
            decimal price;
            while (true)
            {
                Console.SetCursorPosition(60, 19);
                Console.WriteLine("Enter the price.");
                Console.SetCursorPosition(60, 20);
                Console.Write(": ");
                if (!decimal.TryParse(Console.ReadLine(), out price))
                {
                    DisplayErrorMessage.ErrorMessage("invalid price. Erase and please enter a valid number.");
                    continue;
                }
                return price;
            }
        }
    }
}
