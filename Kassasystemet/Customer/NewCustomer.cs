using Kassasystemet.VisualChanges;
using Kassasystemet.Products;
using Kassasystemet.Receipts;
using Kassasystemet.Products.Interface;
using Kassasystemet.Customer.Visual;

namespace Kassasystemet.Customer
{
    public class NewCustomer
    {
        /// <summary>
        /// Handles new customer.
        /// </summary>
        public void StartNewCustormer()
        {
            var salesReceiptCalculate = new SalesReceiptCalculate();
            var salesReceiptPrint = new SalesReceiptPrint();
            var latestReceiptNumber = new SalesReceiptLatestNumber();
            var createBorder = new CreateBorder();
            var productInput = new ProductInput();
            var availiableProductsDisplay = new AvailableProductsDisplay();
            var cartDisplay = new CartDisplay();

            string productFilePath = "../../../Files/Products.txt";

            IProductLoader productLoader = new ProductLoader();
            ProductManager productManager = new ProductManager(productLoader, productFilePath);

            List<Product> shoppingCart = new List<Product>();
            

            string input;
            bool IsPaymentCompleted = false;

            do
            {
                Console.Clear();
                CustomerDisplayBorder.CustomerDrawBorder(createBorder);
                availiableProductsDisplay.DisplayAvailableProducts(productManager);
                cartDisplay.DisplayCustomerCart(salesReceiptCalculate, createBorder, shoppingCart);

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

            salesReceiptPrint.SaveReceipt(shoppingCart, salesReceiptCalculate);

            Console.SetCursorPosition(85, 20);
            Console.WriteLine("Receipt saved and printed out.");
            Console.SetCursorPosition(85, 21);
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
