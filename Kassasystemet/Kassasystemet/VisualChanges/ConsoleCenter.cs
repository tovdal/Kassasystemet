using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet.VisualChanges
{
    public class ConsoleCenter
    {
        // sätter texten till mitten horisontell
        public void CenterText(string text)
        {
            int windowWidth = Console.WindowWidth;
            int textLength = text.Length;
            int spaces = (windowWidth - textLength) / 2;
            Console.WriteLine(new string(' ', spaces) + text);
        }

        // sätter texten till mitten vertikalt
        public void SetCursorToMiddle(int lines)
        {
            int windowHeight = Console.WindowHeight;
            int verticalPosition = (windowHeight - lines) / 2;
            Console.SetCursorPosition(0, verticalPosition);
        }

    }
}
