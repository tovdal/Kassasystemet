using Kassasystemet.Products;

namespace Kassasystemet.Receipts
{
    public class SalesReceiptCalculate
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
