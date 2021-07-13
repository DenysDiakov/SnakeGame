using System;
using System.Collections.Generic;
using System.Linq;
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
			Arena.FindSpace(out int x, out int y);			
			Snakes.Add(new Snake(x, y));
		}

		public void Move()
		{
			Snakes.ForEach(x => x.Move());
		}

		public bool SnakesIsAlive()
		{
			return Snakes.All(x => x.IsAlive());
		}

		public bool IsSnakesOnFood()
		{
			return Snakes.Any(x => x.IsSnakeOnFood());
		}

		public List<Snake> GetOnFoodSnakes()
		{
			return Snakes.Where(x => x.IsSnakeOnFood()).ToList();
		}
	}
}
