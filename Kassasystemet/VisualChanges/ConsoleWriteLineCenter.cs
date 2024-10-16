using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.VisualChanges
{
    public class ConsoleWriteLineCenter
    {
        // sätter texten till mitten horisontell
        public void CenterText(string text)
        {
            int windowWidth = Console.WindowWidth;
            int textLength = text.Length;
            int spaces = Math.Max((windowWidth - textLength) / 2, 0);
            Console.WriteLine(new string(' ', spaces) + text);
        }

        public void CenterTextShort(string text)
        {
            int windowWidth = Console.WindowWidth;
            int textLength = text.Length;
            int spaces = Math.Max((windowWidth - textLength) / 2, 0);
            Console.Write(new string(' ', spaces) + text);
        }


        // sätter texten till mitten vertikalt
        public void SetCursorToMiddle(int lines)
        {
            int windowHeight = Console.WindowHeight;
            int verticalPosition = Math.Max((windowHeight - lines) / 2, 0);
            Console.SetCursorPosition(0, verticalPosition);
        }
    }
}
