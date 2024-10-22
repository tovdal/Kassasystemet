namespace Kassasystemet.Receipts
{
    public class SalesReceiptNumber
    {
        public int CurrentReceiptNumber { get; set; }

        public SalesReceiptNumber(int currentReceiptNumber)
        {
            CurrentReceiptNumber = currentReceiptNumber;
        }
    }
}
