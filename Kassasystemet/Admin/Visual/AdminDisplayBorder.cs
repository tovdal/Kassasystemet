﻿using Kassasystemet.Customer;
using Kassasystemet.Products;
using Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Admin.Display
{
    internal class AdminDisplayBorder
    {
        public void ProductBorder()
        {
            var createBorder = new CreateBorder();
            createBorder.DrawBorder(6, 50, 65, 28); // Products box
            createBorder.DrawBorder(6, 115, 35, 28); //Display Avalible products
            createBorder.DrawBorder(6, 50, 65, 4); // Header Add products
        }

    }
}
