using Kassasystemet.Messages;
using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Admin.AdminAddInput
{
    public class AdminUnitInput
    {
        public UnitType inputUnit()
        {
            UnitType unit;
            while (true)
            {
                Console.SetCursorPosition(60, 21);
                Console.Write("Is the product in 'kg' or 'pc'?");
                Console.SetCursorPosition(60, 22);
                Console.Write(": ");
                string unitInput = Console.ReadLine();
                if (!Enum.TryParse(unitInput, true, out unit) || !Enum.IsDefined(typeof(UnitType), unit))
                {
                    DisplayErrorMessage.ErrorMessage("Invalid unit type. Erase and please enter either 'kg' or 'pc'.");
                    continue;
                }
                return unit;
            }
        }
    }
}
