using System;

namespace SnakeGame
{
	internal class Food : IElement
	{
		public string Sign { get; set; }

		public Coordinates Coordinates { get; set; }

		public ConsoleColor Color { get; set; }

		public Food(Coordinates position)
		{
			Coordinates = position;
			Sign = "@";
			Color = ConsoleColor.Red;
		}
	}
}
