using System.Collections.Generic;

namespace SnakeGame
{
	public class SnakeRepository
	{
		public static List<Snake> Snakes { get; private set; }

		public SnakeRepository()
		{
			Snakes = new List<Snake>();
		}

		public Snake SpawnSnake()
		{
			var snake = new Snake();
			Snakes.Add(snake);
			return snake;
		}
	}
}
