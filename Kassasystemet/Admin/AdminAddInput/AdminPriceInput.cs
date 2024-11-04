using Kassasystemet.Messages;

namespace Kassasystemet.Admin.AdminAddInput
{
    public class AdminPriceInput
    {
        public decimal InputPrice()
        {
            decimal price;
            while (true)
            {
                Message.MessageString("Enter the price.", 60, 19);
                Message.MessageString(": ",60, 20);
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
