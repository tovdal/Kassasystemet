namespace Kassasystemet.VisualChanges
{
    public class ConsoleWriteLineCenter
    {
        public void CenterText(string text)
        {
            int windowWidth = Console.WindowWidth;
            int textLength = text.Length;
            int spaces = Math.Max((windowWidth - textLength) / 2, 0);
            Console.WriteLine(new string(' ', spaces) + text);
        }
        public void DrawBorder(int y, int x, int width, int height)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.Write("╔" + new string('═', width - 2) + "╗"); // Top border

            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("║" + new string(' ', width - 2) + "║"); // Side borders
            }

            Console.SetCursorPosition(x, y + height - 1);
            Console.Write("╚" + new string('═', width - 2) + "╝"); // Bottom border
            Console.ForegroundColor= ConsoleColor.Gray;
        }
    }
}
