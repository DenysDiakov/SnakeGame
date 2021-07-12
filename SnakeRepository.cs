using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
	class SnakeRepository
	{
		public static List<Snake> Snakes { get; set; }

		public SnakeRepository()
		{
			Snakes = new List<Snake>();
		}

		public void SpawnSnake()
		{
			Snakes.Add(new Snake());
		}
	}
}
