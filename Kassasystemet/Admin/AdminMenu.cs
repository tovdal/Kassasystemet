using Kassasystemet.Customer;
using Kassasystemet.Products;
using Kassasystemet.VisualChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Admin
{
    public class AdminMenu
    {
        public void MenuAdmin(IProductLoader productLoader, string filePath)
        {
            var productManager = new ProductManager(productLoader, filePath);
            var updateProducts = new AdminUpdateProducts();
            var addProducts = new AdminAddProduct();
            var adminDisplay = new AdminDisplay();

            bool IsRunningAdmin = true;

            while (IsRunningAdmin)
            {
                adminDisplay.PrintOutAdminMenu();

                string choiceAdminMenu = Console.ReadLine();
                switch (choiceAdminMenu)
                {
                    case "1":
                        addProducts.SaveNewProductToFile(productManager, filePath);
                        break;

                    case "2":
                        // change name
                        updateProducts.ChangeProductName(productManager);
                        break;

                    case "3":
                        updateProducts.ChangeProductPrice(productManager);
                        break;

                    case "4":
                        // back to menu
                        Console.WriteLine("change campain not added yet.");
                        break;

                    case "5":
                        // back to menu
                        IsRunningAdmin = false;
                        break;

                    default:
                        Console.SetCursorPosition(92, 25);
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        
    }
}
