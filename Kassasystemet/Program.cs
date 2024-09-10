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
                    Console.WriteLine("[1] New Costumer");
                    // det man skriver in här ska vara en produkt kod och antal av produkten.
                    // Sedan ska dessa sparas och visas i konsollen.
                    Console.Clear();
                    DateTime now = DateTime.Now;
                    Console.WriteLine("cash register");
                    Console.Write($"RECEIPT      ");
                    Console.Write(now.ToString("yyyy-MM-dd HH:mm:ss"));

                    // här kommer det att vara de produkter som skrivs in och sparas.

                    Console.WriteLine("comands: ");
                    Console.WriteLine("<PLU code> <amount> \n PAY");
                    Console.Write("comand:");
                    // Varor skrivs in och splitras i artikel och antal
                    string userComand = Console.ReadLine();
                    string[] comands = userComand.Split(' ');
                    Console.WriteLine(comands[0]);
                    Console.WriteLine(comands[1]);
                    
                    // PAY ska räkna ihop allt till ett kvitto och slut summa av köpet.
                    // exempel moms, total kostnad, kanske även hur många produkter man köpte totalt

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
    }
}
