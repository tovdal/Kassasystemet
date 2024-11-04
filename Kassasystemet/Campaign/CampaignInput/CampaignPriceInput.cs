using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Campaign.CampaignInput
{
    public class CampaignPriceInput(ProductManager productManager)
    {
        public decimal InputDiscountPrice(int PLUCode)
        {
            decimal discountedPrice;
            while (true)
            {
                Message.MessageString("Enter discounted price.",32, 18);
                Message.MessageString(": ", 32, 19);
                if (!decimal.TryParse(Console.ReadLine(), out discountedPrice))
                {
                    DisplayErrorMessage.ErrorMessage("invalid price. Erase and please enter a valid number.");
                    continue;
                }
                if (discountedPrice >= productManager.GetProductPrice(PLUCode))
                {
                    DisplayErrorMessage.ErrorMessage("Discounted price cannot be equal to or greater than the original price.");
                    continue;
                }
                return discountedPrice;

            }
        }
    }
}
