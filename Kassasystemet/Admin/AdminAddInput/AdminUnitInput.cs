using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Admin.AdminAddInput
{
    public class AdminUnitInput
    {
        public UnitType inputUnit()
        {
            UnitType unit;
            while (true)
            {
                Message.MessageString("Is the product in 'kg' or 'pc'?", 60, 21);
                Message.MessageString(": ", 60, 22);
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
