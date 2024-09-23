using System;
using System.Collections.Generic; // För att använda LISTAN?
using System.IO;

namespace Kassasystemet
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Cashier System 1.0\n");

            Console.WriteLine("[1] New Costumer");
            Console.WriteLine("[2] Admin tools");
            Console.WriteLine("[3] Exit\n");

            Console.Write("Pick selection: ");

            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    //produkt listan skapas
                    List<CartItem> shoppingCart = new List<CartItem>(); // Här ska varorna laggras och sedan kunna visas upp på kvitto
                    string userComand;
                    
                    do
                    {
                        Console.Clear();
                        var todaysDate = DateTime.Now.ToShortDateString();
                        // Dagens datum till kvittot.
                        var receipt = "Kvitto";

                        // det man skriver in här ska vara en produkt kod och antal av produkten.
                        // Sedan ska dessa sparas och visas i konsollen.

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

                            

                            if ()
                        }


                        // PAY ska räkna ihop allt till ett kvitto och slut summa av köpet.
                        // exempel moms, total kostnad, kanske även hur många produkter man köpte totalt

                        // Exempel på hur kvittot ska kunna skrivas ut.
                        //using (StreamWriter myStream = new StreamWriter($"../../../Files/{receipt} Names -{dagensDatum}.txt", append: false))
                        //{
                        //    foreach (string name in names)
                        //    {
                        //        myStream.WriteLine(name);
                        //    }
                        //}

                        //using (StreamReader reader = new StreamReader($"../../../Files/{receipt} Names -{dagensDatum}.txt"))
                        //{
                        //    while (reader.Peek() >= 0)
                        //    {
                        //        Console.WriteLine(reader.ReadLine());
                        //    }
                        //}
                        if (File.Exists("../../../Files/MyWares.txt")) return;

                        string text =
                            "1000:Milk 1L 1,5 %:12,95:pc \n" +
                            "1001:Heavy whipping cream 2,5dl 36 %:18,50:pc \n" +
                            "1002:Cottage cheese 4 % 250g: 16,50:pc \n" +
                            "1003:Cottage cheese 4 % 500g: 30,95:pc \n" +
                            "1007:Fiskpinnar 45,90:pc \n" +
                            "2003 Dill 22,90:kg \n";

                        File.WriteAllText("../../../Files/MyWares.txt", text);
                        //Ska fortsätta med denna lista
                    }
                    while (userComand.ToUpper() != "PAY");

                    // Kvittot måst skrivas ut här?

                    break;

                case 2:
                    Console.WriteLine("[2] Admin tools");
                    switch (num)
                    {
                        case 1:
                            Console.WriteLine("[1] Change product information");
                            // Här inne kommer det att ligga information om produkter. Man ska kunda ändra produkterna eller tabort dem / addera nya!

                            break;

                        case 2:
                            Console.WriteLine("[2] Change deals and promotional prices");
                            // här inne kommer det att ligga information om kampanjpriser
                            // "Det som menas är att tex från 2023-03-18 till 2023-03-19 kostar mjölken 10 kr"
                            // Man ska kunna tabort och lägga till
                            // kampanjpriserna måste var med på kvitto!!!

                            //ToChar
                            Console.WriteLine("Vilken produkt letar du efter?");
                            string imput = Console.ReadLine();
                            ushort shortSearch = Convert.ToUInt16(Console.ReadLine()[0]);

                            // Fortsätt vidare senare


                            break;

                        case 3:
                            Console.WriteLine("[3] Return");
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("[3] Exit");
                    break;

            }

        }


        static Item WareByPLUCode(string pluCode)
        {
            if 
        }
    }
}
