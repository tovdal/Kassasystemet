using Kassasystemet.Admin;
using Kassasystemet.Products;
using Kassasystemet.Products.Interface;

namespace Kassasystemet.Menu.AdminM
{
    public class AdminMenu
    {
        public void MenuAdmin(IProductLoader productLoader, string filePath)
        {
            var productManager = new ProductManager(productLoader, filePath);
            var updateProducts = new AdminManager();
            var PLUfinder = new AdminPLUFinder();
            var addProducts = new AdminAddProduct();
            var adminDisplay = new AdminMenuDisplay();

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
                        updateProducts.ChangeProductName(productManager, PLUfinder);
                        break;

                    case "3":
                        updateProducts.ChangeProductPrice(productManager, PLUfinder);
                        break;

                    case "4":
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
