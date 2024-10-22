namespace Kassasystemet.Products
{

    /// <summary>
    /// Product that has properties: PLUCode, product name, price and unit
    /// </summary>
    public class Product
    {
        public int PLUCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1; //default value
        public UnitType Unit { get; set; }

        public Product(int pluCode, string productName, decimal price, UnitType unit)
        {
            PLUCode = pluCode;
            ProductName = productName;
            Price = price;
            Unit = unit;
        }
    }

    /// <summary>
    /// Defines Unit types
    /// </summary>
    public enum UnitType
    {
        pc,
        kg
    }
}
