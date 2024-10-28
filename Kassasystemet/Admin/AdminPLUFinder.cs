using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Admin
{
    public class AdminPLUFinder
    {
        public Product FindPLUCode(ProductManager productManager)
        {
            int PLUCode = 0;
            Console.SetCursorPosition(52, 15);
            Console.Write("Enter the PLUCode of the product you want to change:");
            try
            {
                PLUCode = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.SetCursorPosition(83, 38);
                Console.WriteLine("You must enter a valid PLU number");
            }

            Product productToChange = productManager.GetProductByPLU(PLUCode);
            if (productToChange == null)
            {
                Console.SetCursorPosition(83, 38);
                Console.WriteLine("Product not found");
                Console.ReadKey();
                return null;
            }
            return productToChange;
        }
    }
}
