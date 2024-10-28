using Kassasystemet.Admin.Display;
using Kassasystemet.Customer;
using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminManager
    {

        public void ChangeProductName(ProductManager productManager, AdminPLUFinder adminPLUFinder)
        {
            var changeName = new AdminChangeProductName();
            changeName.ChangeNameProduct(productManager, adminPLUFinder);
        }

        public void ChangeProductPrice(ProductManager productManager, AdminPLUFinder adminPLUFinder)
        {
            var changePrice = new AdminChangeProductPrice();
            changePrice.ChangePriceProduct(productManager, adminPLUFinder);
        }
    }
}
