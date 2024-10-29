using Kassasystemet.VisualChanges;
using Kassasystemet.Products;
using Kassasystemet.Receipts;
using Kassasystemet.Products.Interface;
using Kassasystemet.Customer.DisplayBorder;
using Kassasystemet.Campaign;


namespace Kassasystemet.Customer
{
    public class NewCustomer
    {
        /// <summary>
        /// Handles new customer.
        /// </summary>
        public void StartNewCustormer()
        {
            var salesReciptCalculator = new SalesReceiptCalculate();
            var salesReceiptPrint = new SalesReceiptPrint();
            var latestReceiptNumber = new SalesReceiptLatestNumber();
            var createBorder = new CreateBorder();
            var productInput = new ProductInput();
            var availiableProductsDisplay = new AvailableProductsDisplay();
            var cartDisplay = new CartDisplay();

            string productFilePath = "../../../Files/Products.txt"; //Filvägen till produkterna

            IProductLoader productLoader = new ProductLoader();
            ProductManager productManager = new ProductManager(productLoader, productFilePath);

            List<Product> shoppingCart = new List<Product>();
            

            string input;
            bool IsPaymentCompleted = false;

            do
            {
                Console.Clear();
                CustomerBorderDisplay.CustomerDrawBorder(createBorder);
                availiableProductsDisplay.DisplayAvailableProducts(productManager);
                cartDisplay.DisplayCustomerCart(salesReciptCalculator, createBorder, shoppingCart);

                input = Console.ReadLine();

                if (input.ToUpper() != "PAY")
                {
                    productInput.HandleProductInput(createBorder, productManager, shoppingCart, input);
                }
                else
                {
                    IsPaymentCompleted = true;
                }
            }
            while (!IsPaymentCompleted);

            salesReceiptPrint.SaveReceipt(shoppingCart, salesReciptCalculator); //När betalningen är klart, kvittot sparas.

            Console.SetCursorPosition(85, 20);
            Console.WriteLine("Receipt saved and printed out.");
            Console.SetCursorPosition(85, 21);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
