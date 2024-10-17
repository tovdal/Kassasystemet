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

        public void DrawBorder(int y, int x, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("╔" + new string('═', width - 2) + "╗"); // Top border

            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("║" + new string(' ', width - 2) + "║"); // Side borders
            }

            Console.SetCursorPosition(x, y + height - 1);
            Console.Write("╚" + new string('═', width - 2) + "╝"); // Bottom border
        }
    }
}
