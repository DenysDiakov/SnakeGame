using System;

namespace SnakeGame
{
	public interface IElement
	{
		public Coordinates Coordinates { get; set; }

		public string Sign { get; set; }

		public ConsoleColor Color { get; set; }
	}
}
