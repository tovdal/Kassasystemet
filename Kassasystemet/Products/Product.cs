
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

        public decimal? CampaignPrice { get; set; } //Optional properties
        public DateTime? CampaignStart { get; set; }
        public DateTime? CampaignEnd { get; set; }

        public Product(int pluCode, string productName, decimal price, UnitType unit)
        {
            PLUCode = pluCode;
            ProductName = productName;
            Price = price;
            Unit = unit;
        }


        public decimal GetCurrentPrice()
        {
            if (CampaignPrice.HasValue && CampaignStart.HasValue && CampaignEnd.HasValue)
            {
                DateTime today = DateTime.Now;
                if (today >= CampaignStart.Value && today <= CampaignEnd.Value)
                {
                    return CampaignPrice.Value;
                }
            }
            return Price;
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
