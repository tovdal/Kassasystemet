using Kassasystemet.VisualChanges;
using Kassasystemet.Products;
using Kassasystemet.Receipts;


namespace Kassasystemet.Customer
{
    public class NewCustomer
    {

        public void StartNewCustormer()
        {
            var calculateReceipt = new CalculateReceipt();
            var salesReceipt = new PrintSalesReceipt();
            var latestReceiptNumber = new LatestReceiptNumber();
            var consoleCenter = new ConsoleWriteLineCenter();

            // hanterar kund
            string productFilePath = "../../../Files/products.txt"; //Filvägen till produkterna

            IProductLoader productLoader = new ProductLoader();
            ProductManager productManager = new ProductManager(productLoader, productFilePath, consoleCenter);

            List<Product> shoppingCart = new List<Product>();

            string input;
            bool IsPaymentCompleted = false;

            do
            {
                DisplayProducts.DisplayAvailableProducts(productManager);
                DisplayReceipt.DisplayCustomerReceipt(calculateReceipt, consoleCenter, shoppingCart);

                input = Console.ReadLine();

                if (input.ToUpper() != "PAY")
                {
                    CustomerImput.HandleProductInput(consoleCenter, productManager, shoppingCart, input);
                }
                else
                {
                    IsPaymentCompleted = true;
                }
            }
            while (!IsPaymentCompleted);

            salesReceipt.SaveReceipt(shoppingCart, calculateReceipt); //När betalningen är klart, kvittot sparas.

            consoleCenter.CenterText("Receipt saved and printed out.");
            consoleCenter.CenterText("Press any key to continue");
            Console.ReadKey();
        }

    }
}
