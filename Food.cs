using System;

namespace SnakeGame
{
	class Food : IElement
	{
		public int XPosition { get; set; }

		public int YPosition { get; set; }

		public string Sign { get; set; }

		public ConsoleColor Color { get; set; }

		public Food(int x, int y)
		{
			XPosition = x;
			YPosition = y;
			Sign = "@";
			Color = ConsoleColor.Red;
		}
	}
}
