using Kassasystemet.Messages;

namespace Kassasystemet.Admin.AdminAddInput
{
    public class AdminNameInput
    {
        public string InputName()
        {
            string productName;
            while (true)
            {
                Message.MessageString("Enter the name of the product.", 60, 17);
                Message.MessageString(": ", 60, 18);
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
