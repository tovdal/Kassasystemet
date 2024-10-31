namespace Kassasystemet.Campaign
{
    public class Campaign
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int PLUCode { get; set; }

        public Campaign(DateTime startDate, DateTime endDate, decimal discountedPrice, int pluCode) 
        {
            StartDate = startDate;
            EndDate = endDate;
            DiscountedPrice = discountedPrice;
            PLUCode = pluCode;
        }

        public bool IsCampaignActive (DateTime date)
        {
            return date >= StartDate && date <= EndDate;
        }
    }
}
