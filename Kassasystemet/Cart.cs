using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet
{
    internal class Cart
    {
        private List<Product> items = new List<Product>();

        public void AddProduct(Product product)
        { 
            items.Add(product); 
        }
    }
}
