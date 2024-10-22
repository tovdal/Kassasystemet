namespace Kassasystemet.Receipts
{
    public class ReceiptNumber
    {
        public int CurrentReceiptNumber { get; set; }

        public ReceiptNumber(int currentReceiptNumber)
        {
            CurrentReceiptNumber = currentReceiptNumber;
        }
    }
}
