using Kassasystemet.Messages;

namespace Kassasystemet.Campaign.CampaignInput
{
    public class CampaignDateInput()
    {
        public DateTime InputStartDate()
        {
            DateTime startDate;
            while (true)
            {
                Message.MessageString("Enter start date(yyyy-mm-dd or yyyy.mm.dd)", 32, 14);
                Message.MessageString(": ", 32, 15);
                string startDateInput = Console.ReadLine();
                if (!DateTime.TryParse(startDateInput, out startDate))
                {
                    DisplayErrorMessage.ErrorMessage("Invalid date format. Erase and please enter a date in the format yyyy-mm-dd.");
                    continue;
                }
                if (startDate < DateTime.Now.Date)
                {
                    DisplayErrorMessage.ErrorMessage("The start date must be today or in the future.");
                    continue;
                }
                return startDate;
            }
        }
        public DateTime InputEndDate(DateTime startDate)
        {
            DateTime endDate;
            while (true)
            {
                Message.MessageString("Enter end date(yyyy-mm-dd or yyyy.mm.dd)",32, 16);
                Message.MessageString(": ",32, 17);
                string endDateInput = Console.ReadLine();
                if (!DateTime.TryParse(endDateInput, out endDate))
                {
                    DisplayErrorMessage.ErrorMessage("Invalid date format. Erase and please enter a date in the format yyyy-mm-dd.");
                    continue;
                }
                if (endDate < startDate)
                {
                    DisplayErrorMessage.ErrorMessage("End date must be tomorrow or later. Erase and please enter a new date");
                    continue;
                }
                return endDate;
            }
        }
    }
}
