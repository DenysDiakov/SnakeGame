using System;

namespace SnakeGame
{
	public class SnakePart : IElement
	{
		public string Sign { get; set; }

		public ConsoleColor Color { get; set; }

		public Coordinates Coordinates { get; set; }

		public SnakePart(Coordinates position, string sign = "0")
		{
			Coordinates = position;
			Sign = sign;
			Color = ConsoleColor.Green;
		}
	}
}
