using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Messages
{
    public class DisplayErrorMessage
    {
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(80, 38);
            Console.Write(message);
            Console.ResetColor();
            Console.Write(new string(' ', message.Length));
            Console.ReadKey();
        }
    }
}
