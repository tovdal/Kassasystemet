﻿using Kassasystemet.VisualChanges;

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
