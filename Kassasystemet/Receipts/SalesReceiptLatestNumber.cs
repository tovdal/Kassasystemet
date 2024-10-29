namespace Kassasystemet.Receipts
{
    public class SalesReceiptLatestNumber
    {
        private string SalesReceiptLatestNumberFilePath = $"../../../Files/LatestReceiptNumber.txt";

        public int GetAndSaveLatestReceiptNumber()
        {
            int latestNumber = 0;

            try
            {
                if (File.Exists(SalesReceiptLatestNumberFilePath))
                {
                    string readLine = File.ReadAllText(SalesReceiptLatestNumberFilePath);
                    int.TryParse(readLine, out latestNumber);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while reading receipt number: " + ex.Message);
            }

            latestNumber += 1;

            try
            {
                File.WriteAllText(SalesReceiptLatestNumberFilePath, latestNumber.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while saving receipt number: " + ex.Message);
            }

            return latestNumber;
        }
    }
}
