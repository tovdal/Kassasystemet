using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet
{
    internal class HandelNewCustomer
    {
        static void HandleCustomer()
        {
            List<Product> shoppingCart = new List<Product>();
            Receipt receipt1 = new Receipt();
            string userComand;

            do
            {
                Console.Clear();
                var todaysDate = DateTime.Now.ToShortDateString();
                var receipt = "Kvitto";

                Console.WriteLine("CASH REGISTER");
                Console.Write($"RECEIPT      " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("\n");

                foreach (var item in shoppingCart)
                {
                    Console.WriteLine($"{item.Name} {item.Amount} * {item.Price} = {item.Amount * item.Price}");
                }

                Console.WriteLine($"Total: {CalculateTotal(shoppingCart)}"); //Måste ha något sätt att räkna ihop alla varor.
                Console.WriteLine("<PLU code> <amount> PAY");
                Console.Write("Command:");

                // Varor skrivs in och splitras i artikel och antal
                userComand = Console.ReadLine();
                string[] comands = userComand.Split(' ');

                if (comands[0].ToUpper() != "PAY")
                {
                    string pluCode = comands[0];
                    ushort amount = ushort.Parse(comands[1]);
                }


                // PAY ska räkna ihop allt till ett kvitto och slut summa av köpet.
                // exempel moms, total kostnad, kanske även hur många produkter man köpte totalt
                //Ska fortsätta med denna lista
            }
            while (userComand.ToUpper() != "PAY");

            // Kvittot måst skrivas ut här?
        }
    }
}
