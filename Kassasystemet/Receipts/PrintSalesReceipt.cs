using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystemet.Customer;
using Kassasystemet.Products;

namespace Kassasystemet.Receipts
{
    // Hanterar produkter som köpts och ansvarar för att beräkna totalsumman samt skriva ut kvittot.
    public class PrintSalesReceipt
    {
        public void SaveReceipt(List<Product> shoppingCart, CalculateReceipt calculateReceipt)
        {
            var uniqueProducts = CartUniqProducts.GatherProducts(shoppingCart);
            var latestReceiptNumber = new LatestReceiptNumber();
            int receiptNumber;

            string receiptFilePath = $"../../../Files/RECEIPT_{DateTime.Now:yyyyMMdd}.txt";
            using (StreamWriter writer = new StreamWriter(receiptFilePath, append: true))
            {
                writer.WriteLine(" _______________________________________");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|=============== RECEIPT ===============|");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|Super Market - NoWhere                 |");
                writer.WriteLine("|No-Where Steet 0                       |");
                writer.WriteLine("|234 56 No-Where                        |");
                writer.WriteLine("|TEL NR 010-0000000                     |");
                writer.WriteLine($"|Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}              |");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|---------------------------------------|");
                foreach (var product in uniqueProducts)
                {
                    writer.WriteLine($"|{product.ProductName} {product.Quantity} * {product.Price:C} = {product.Quantity * product.Price:C}");
                }
                writer.WriteLine("|                                       |");
                writer.WriteLine($"|Articles: {shoppingCart.Count}");
                writer.WriteLine($"|Total: {calculateReceipt.CalculateTotal(shoppingCart):C}");
                writer.WriteLine($"|Taxes: {calculateReceipt.CalculateTax(shoppingCart):C}");
                writer.WriteLine("|---------------------------------------|");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|           THANKS AND WELCOME          |");
                writer.WriteLine("|            BACK TO THE SHOP           |");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|               cashier 1               |");

                writer.WriteLine($"|           Receipt Number: {receiptNumber = latestReceiptNumber.GetAndSaveLatestReceiptNumber()}          |");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|        ****** ORIGINAL *******        |");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|=======================================|");
                writer.WriteLine("|                                       |");
                writer.WriteLine("|_______________________________________|");
                writer.WriteLine("\n\n");
            }

            Console.Clear();
        }
    }
}
