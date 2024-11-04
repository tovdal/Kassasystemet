using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Messages
{
    public class Message
    {
        public static void MessageString(string message, int moveX, int moveY)
        {
            Console.SetCursorPosition(moveX, moveY);
            Console.Write(message);
        }
    }
}
