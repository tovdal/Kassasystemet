using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet
{
    public class CashRegister
    {
        private Dictionary<int, Product> products = new Dictionary<int, Product>();

        public CashRegister(string filePath)
        {
            LoadProducts(filePath);
        }

        private void LoadProducts(string filePath)
        {
            // Läser in produkter från fil
        }

        public bool TryGetProduct(int pluCode, out Product product)
        {
            return products.TryGetValue(pluCode, out product);
        }
    }

}
