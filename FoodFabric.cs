using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
	static class FoodFabric
	{
		private static Visualizer _visualizer;

		public static List<Food> Foods { get; private set; }

		static FoodFabric()
		{
			_visualizer = new Visualizer();
			Foods = new List<Food>();
		}

		static public void SpawnFood()
		{
			int x, y = 0;
			Arena.FindSpace(out x, out y);
			Food food = new Food(x, y);
			Foods.Add(food);
			print(food);
		}

		static public void DeleteFood(int x, int y)
		{
			var food = Foods.Where(food => food.XPosition == x && food.YPosition == y).FirstOrDefault();
			Foods.Remove(food);
			food.Sign = string.Empty;
			print(food);
		}

		private static void print(IElement food)
		{
			_visualizer.PrintElement(food);
		}
	}
}
