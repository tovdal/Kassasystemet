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
                Console.Clear();

                consoleCenter.DrawBorder(7, 50, 65, 25); // New Customer
                consoleCenter.DrawBorder(7, 115, 35, 25); //Available products
                consoleCenter.DrawBorder(32, 50, 100, 3); //Comand box
                consoleCenter.DrawBorder(28, 50, 65, 4); // total box.


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

            Console.SetCursorPosition(85, 20);
            Console.WriteLine("Receipt saved and printed out.");
            Console.SetCursorPosition(85, 21);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
