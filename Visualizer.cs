using System;

namespace SnakeGame
{
	class Visualizer
	{
		public Visualizer()
		{
			Console.CursorVisible = false;
			const int width = 55;
			const int height = 25;
			Console.SetWindowSize(width, height);
			Console.SetBufferSize(width + 5, height + 5);
		}

		public void WriteAt(int x, int y, string sign, ConsoleColor color)
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
				WriteAt(e.XPosition, e.YPosition, e.Sign, e.Color);
			}
		}
	}
}
