using System.Collections.Generic;

namespace SnakeGame
{
	class SnakeRepository
	{
		public static List<Snake> Snakes { get; set; }

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
