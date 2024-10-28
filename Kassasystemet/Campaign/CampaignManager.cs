using Kassasystemet.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Campaign
{
    public class CampaignManager
    {
        private List<Campaign> campaigns = new List<Campaign>();
        private string campaignFilePath = "../../../Files/Campaign.txt";

        public CampaignManager() 
        {
            LoadCampaignsFromFile();
        }
        public void AddCampaign(Campaign campaign)
        {
            campaigns.Add(campaign);
            SaveCampaignsToFile();
        }

        public bool RemoveCampaign(int pluCode, DateTime startDate)
        {
            for (int i = 0; i < campaigns.Count; i++)
            {
                if (campaigns[i].PLUCode == pluCode && campaigns[i].StartDate == startDate)
                {
                    campaigns.RemoveAt(i);
                    SaveCampaignsToFile();
                    return true;
                }
            }
            return false;
        }

        public List<Campaign> GetCampaigns(int pluCode)
        {
            List<Campaign> result = new List<Campaign>();
            foreach (var campaign in campaigns)
            {
                if (campaign.PLUCode == pluCode)
                {
                    result.Add(campaign);
                }
            }
            return result;
        }

        public void LoadCampaignsFromFile()
        {
            if (File.Exists(campaignFilePath))
            {
                foreach (var line in File.ReadAllLines(campaignFilePath))
                {
                    var parts = line.Split(':');
                    DateTime startDate = DateTime.Parse(parts[0]);
                    DateTime endDate = DateTime.Parse(parts[1]);
                    decimal discountedPrice = decimal.Parse(parts[2]);
                    int pluCode = int.Parse(parts[3]);

                    campaigns.Add(new Campaign(startDate, endDate, discountedPrice, pluCode));
                }
            }
        }

        public void SaveCampaignsToFile()
        {
            using (StreamWriter writer = new StreamWriter(campaignFilePath, false)) // Overwrite the file
            {
                foreach (var campaign in campaigns)
                {
                    writer.WriteLine($"{campaign.StartDate:yyyy-MM-dd}:{campaign.EndDate:yyyy-MM-dd}:{campaign.DiscountedPrice}:{campaign.PLUCode}");
                }
            }
        }
        public decimal GetPriceWithCampaigns(Product product, DateTime date)
        {
            decimal discountedPrice = product.Price;

            foreach (var campaign in campaigns)
            {
                if (campaign.PLUCode == product.PLUCode && campaign.StartDate <= date && campaign.EndDate >= date)
                {
                    discountedPrice = campaign.DiscountedPrice; 
                    break;
                }
            }

            return discountedPrice;
        }
        public List<Campaign> GetCampaigns()
        {
            return campaigns;
        }
    }
}
