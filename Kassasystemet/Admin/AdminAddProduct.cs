using Kassasystemet.Products;

namespace Kassasystemet.Admin
{
    public class AdminAddProduct
    {
        public void SaveNewProductToFile(ProductManager productManager, string filePath)
        {
            Console.WriteLine("Enter the PLU of the product: ");
            int PLUCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name of the product: ");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter the price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("invalid price. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Is the product in kg or pc? (Enter 'kg' or 'pc')");
            string unitInput = Console.ReadLine();
            UnitType unit;

            if (!Enum.TryParse(unitInput, true, out unit))
            {
                Console.WriteLine("Invalid unit type. Please enter either 'kg' or 'pc'.");
                return;
            }

            Product product = new Product(PLUCode, productName, price, unit);

            productManager.AddProduct(product, filePath);

            Console.WriteLine("Product added successfully.");
            Console.ReadKey();

        }
    }
}
