using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
	static class FoodFabric
	{
		public static List<Food> Foods { get; private set; }

		static FoodFabric()
		{
			Foods = new List<Food>();
		}

		static public void SpawnFood(IEnumerable<IElement> elements)
		{
			Random r = new Random();
			int x = 0;
			int y = 0;
			do
			{
				x = r.Next(Console.WindowWidth - 1);
				y = r.Next(Console.WindowHeight - 1);
			}
			while (elements.Any(s => s.XPosition == x && s.YPosition == y));
			Food food = new Food(r.Next(Console.WindowWidth - 1), r.Next(Console.WindowHeight - 1));
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
			var visualizer = new Visualizer();
			visualizer.PrintElement(food);
		}
	}
}
