using Kassasystemet.Kassasystemet.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet.Receipt
{
    public class CalculateReceipt
    {
        public decimal CalculateTotal(List<Product> shoppingCart)
        {
            decimal total = 0;

            foreach (var product in shoppingCart)
            {
                total += product.Price;
            }
            return total;
        }
        public decimal CalculateTax(List<Product> shoppingCart)
        {
            decimal tax = 0;

            foreach (var product in shoppingCart)
            {
                tax += product.Price;
            }
            tax *= 0.12m;

            return tax;
        }
    }
}
