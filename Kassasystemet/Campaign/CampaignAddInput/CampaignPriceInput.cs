using Kassasystemet.Messages;
using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Campaign.CampaignAddInput
{
    public class CampaignPriceInput(ProductManager productManager)
    {
        public decimal InputDiscountPrice(int PLUCode)
        {
            decimal discountedPrice;
            while (true)
            {
                Console.SetCursorPosition(32, 18);
                Console.WriteLine("Enter discounted price.");
                Console.SetCursorPosition(32, 19);
                Console.Write(": ");
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
