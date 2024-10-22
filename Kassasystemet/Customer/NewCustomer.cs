using Kassasystemet.VisualChanges;
using Kassasystemet.Products;
using Kassasystemet.Receipts;


namespace Kassasystemet.Customer
{
    public class NewCustomer
    {
        /// <summary>
        /// Handles new customer.
        /// </summary>
        public void StartNewCustormer()
        {
            var calculateReceipt = new SalesReceiptCalculate();
            var salesReceipt = new SalesReceiptPrint();
            var latestReceiptNumber = new SalesReceiptLatestNumber();
            var consoleCenter = new ConsoleWriteLineCenter();
            var customerImput = new CustomerImput();

            string productFilePath = "../../../Files/products.txt"; //Filvägen till produkterna

            IProductLoader productLoader = new ProductLoader();
            ProductManager productManager = new ProductManager(productLoader, productFilePath);

            List<Product> shoppingCart = new List<Product>();

            string input;
            bool IsPaymentCompleted = false;

            do
            {
                Console.Clear();
                CustomerBorderDisplay.CustomerDrawBorder(consoleCenter);
                AvailableProductsDisplay.DisplayAvailableProducts(productManager);
                CartDisplay.DisplayCustomerCart(calculateReceipt, consoleCenter, shoppingCart);

                input = Console.ReadLine();

                if (input.ToUpper() != "PAY")
                {
                    customerImput.HandleProductInput(consoleCenter, productManager, shoppingCart, input);
                }
                else
                {
                    IsPaymentCompleted = true;
                }
            }
            while (!IsPaymentCompleted);

            salesReceipt.SaveReceipt(shoppingCart, calculateReceipt); //När betalningen är klart, kvittot sparas.

            Console.SetCursorPosition(85, 20);
            Console.WriteLine("Receipt saved and printed out.");
            Console.SetCursorPosition(85, 21);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
