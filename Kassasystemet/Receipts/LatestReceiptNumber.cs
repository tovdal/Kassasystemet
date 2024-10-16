namespace Kassasystemet.Receipts
{
    public class LatestReceiptNumber
    {
        private string latestReceiptNumberFilePath = $"../../../Files/LatestReceiptNumber.txt";

        public int GetAndSaveLatestReceiptNumber()
        {
            int latestNumber = 0; // Default to 0

            try
            {
                if (File.Exists(latestReceiptNumberFilePath))
                {
                    string readLine = File.ReadAllText(latestReceiptNumberFilePath);
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
                File.WriteAllText(latestReceiptNumberFilePath, latestNumber.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while saving receipt number: " + ex.Message);
            }

            return latestNumber;
        }
    }
}
