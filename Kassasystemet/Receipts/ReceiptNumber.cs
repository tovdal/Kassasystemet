using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
