using Kassasystemet.Messages;
using Kassasystemet.Products;

namespace Kassasystemet.Customer
{
    public class AvailableProductsDisplay
    {
        public void DisplayAvailableProducts(ProductManager productManager)
        {
            Message.MessageString("Available Products:",119, 8);

            int currentRow = 10;

            foreach (var product in productManager.GetProducts())
            {
                Console.SetCursorPosition(119, currentRow);
                Console.WriteLine($"PLU: {product.PLUCode} - {product.ProductName} - {product.Unit}");
                currentRow++;
            }
        }
    }
}
