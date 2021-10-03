using System;

namespace SnakeGame
{
	public class Visualizer
    {
        static Visualizer()
		{
            const int width = 55;
            const int height = 25;

            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width + 1, height + 1);
		}       

        public static void PrintElements(params IElement[] element)
        {
			foreach (var e in element)
			{
                writeAt(e.Sign, e.Coordinates.X, e.Coordinates.Y, e.Color);
			}
        }

        private static void writeAt(string sign, int x, int y, ConsoleColor color)
        {
            try
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x, y);
                Console.Write(sign);
                Console.ResetColor();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
}
