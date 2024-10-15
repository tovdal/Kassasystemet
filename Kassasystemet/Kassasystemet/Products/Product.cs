using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet.Register
{
    // Representerar en produkt med egenskaper som PLU-kod, produktnamn, pris och enhet.
    public class Product
    {
        public int PLUCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public UnitType Unit { get; set; }

        public Product(int pluCode, string productName, decimal price, UnitType unit)
        {
            PLUCode = pluCode;
            ProductName = productName;
            Price = price;
            Unit = unit;
        }
    }
    // Enum för att definiera enheterna av produkterna - den kan stanna kvar här inne.
    public enum UnitType
    {
        pc, //Styck
        kg //Kilogram
    }
}
