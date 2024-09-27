using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet
{
    internal class HandelCustomer
    {
        private CashRegister CashRegister;
        public HandelCustomer() 
        {
            CashRegister cashRegister1 = new CashRegister("../../../Files/{receipt} Names -{TodayDate}.txt"); // ??????????????????????????
        }

        static void HandleNewCustomer()
        {
            List<Product> shoppingCart = new List<Product>();
            Receipt receipt1 = new Receipt();
            string userComand;

            do
            {
                Console.Clear();
                Console.WriteLine("CASH REGISTER");
                Console.Write($"RECEIPT      " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("\n");

                foreach (var product in shoppingCart)
                {
                    Console.WriteLine($"{product.ProductName} {product.Quantity} * {product.Price} = {product.Quantity * product.Price}"); // varför blir Quantity jordgubbsland
                }

                Console.WriteLine($"Total: {receipt1.TotalAmount}"); //Måste ha något sätt att räkna ihop alla varor.
                Console.WriteLine("<PLU code> <amount> PAY");
                Console.Write("Command:");

                // Varor skrivs in och splitras i artikel och antal
                userComand = Console.ReadLine();
                string[] comands = userComand.Split(' ');

                if (comands[0].ToUpper() != "PAY")
                {
                    int pluCode = int.Parse(comands[0]);
                    ushort amount = ushort.Parse(comands[1]);
                }


                // PAY ska räkna ihop allt till ett kvitto och slut summa av köpet.
                // exempel moms, total kostnad, kanske även hur många produkter man köpte totalt
                //Ska fortsätta med denna lista
            }
            while (userComand.ToUpper() != "PAY");

            // Kvittot måst skrivas ut här?
            //var todaysDate = DateTime.Now.ToShortDateString();
        }
    }
}
