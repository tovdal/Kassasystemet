﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Kassasystemet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Måste städa upp och börja om

            Console.WriteLine("Cashier System 1.0\n");

            Console.WriteLine("[1] New Costumer");
            Console.WriteLine("[2] Admin tools");
            Console.WriteLine("[3] Exit\n");

            Console.Write("Pick selection: ");

            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                   //HandelNewCustomer();
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
