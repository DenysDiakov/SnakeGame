using System;

namespace SnakeGame
{
	class Visualizer
    {
        public Visualizer()
		{
            int width = 55;
            int height = 25;
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
		}

        public void WriteAt(string sign, int x, int y, ConsoleColor color)
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

        public void PrintElement(params IElement[] element)
        {
			foreach (var e in element)
			{
                WriteAt(e.Sign, e.XPosition, e.YPosition, e.Color);
			}
        }
    }
}
