using Kassasystemet.Products;

namespace Kassasystemet.Customer
{
    public class AvailableProductsDisplay
    {
        public static void DisplayAvailableProducts(ProductManager productManager)
        {
            Console.SetCursorPosition(119, 8);
            Console.WriteLine("Available Products:");


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
