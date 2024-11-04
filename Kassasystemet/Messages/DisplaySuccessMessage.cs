using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Messages
{
    public class DisplaySuccessMessage
    {
        public static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(80, 38);
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
