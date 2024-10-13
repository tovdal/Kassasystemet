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
            int spaces = Math.Max((windowWidth - textLength) / 2, 0);
            Console.WriteLine(new string(' ', spaces) + text);
        }

        // sätter texten till mitten vertikalt
        public void SetCursorToMiddle(int lines)
        {
            int windowHeight = Console.WindowHeight;
            int verticalPosition = Math.Max((windowHeight - lines) / 2, 0);
            Console.SetCursorPosition(0, verticalPosition);
        }

        public void CenterAndDisplay(string text)
        {
            Console.Clear();  // Clear the console

            // Get the console dimensions
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            // Calculate the horizontal and vertical positions
            int textLength = text.Length;
            int horizontalSpaces = Math.Max((windowWidth - textLength) / 2, 0); // Prevent negative spaces
            int verticalPosition = Math.Max((windowHeight - 1) / 2, 0); // Prevent negative position

            // Set cursor position and display text
            Console.SetCursorPosition(horizontalSpaces, verticalPosition);
            Console.WriteLine(text);
        }
    }
}
