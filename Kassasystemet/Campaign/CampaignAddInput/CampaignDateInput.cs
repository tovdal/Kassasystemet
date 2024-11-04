using Kassasystemet.Messages;

namespace Kassasystemet.Campaign.CampaignAddInput
{
    public class CampaignDateInput()
    {
        public DateTime InputStartDate()
        {
            DateTime startDate;
            while (true)
            {
                Console.SetCursorPosition(32, 14);
                Console.WriteLine("Enter start date (yyyy-mm-dd).");
                Console.SetCursorPosition(32, 15);
                Console.Write(": ");
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
                Console.SetCursorPosition(32, 16);
                Console.WriteLine("Enter end date (yyyy-mm-dd).");
                Console.SetCursorPosition(32, 17);
                Console.Write(": ");
                string endDateInput = Console.ReadLine();
                if (!DateTime.TryParse(endDateInput, out endDate))
                {
                    DisplayErrorMessage.ErrorMessage("Invalid date format. Erase and please enter a date in the format yyyy-mm-dd.");
                    continue;
                }
                if (endDate < startDate)
                {
                    DisplayErrorMessage.ErrorMessage("The end date must be the day after the start date or in the future. Erase and please enter a date..");
                    continue;

                }
                return endDate;
            }
        }
    }
}
