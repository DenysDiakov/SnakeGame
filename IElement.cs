using System;

namespace SnakeGame
{
	interface IElement
	{
		public int XPosition { get; set; }

		public int YPosition { get; set; }

		public string Sign { get; set; }

		public ConsoleColor Color { get; set; }
	}
}
