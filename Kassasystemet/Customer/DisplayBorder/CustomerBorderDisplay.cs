﻿using Kassasystemet.VisualChanges;

namespace Kassasystemet.Customer.DisplayBorder
{
    public class CustomerBorderDisplay
    {
        public static void CustomerDrawBorder(CreateBorder createBorder)
        {
            createBorder.DrawBorder(6, 50, 65, 26); // Products box
            createBorder.DrawBorder(6, 115, 35, 28); //Available products
            createBorder.DrawBorder(34, 50, 100, 3); //Comand box
            createBorder.DrawBorder(30, 50, 65, 4); // total box and taxes.
            createBorder.DrawBorder(6, 50, 65, 4); // Header - Cash Regiser

        }

    }
}
