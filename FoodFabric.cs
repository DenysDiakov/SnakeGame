using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
	static class FoodFabric
	{
		// To do normal initialization
		public static List<IElement> Foods { get; private set; } = new List<IElement>();

		static public void SpawnFood()
		{
			Random r = new Random();
			// To do spawn food where snake is not exists
			IElement food = new Food(r.Next(Console.WindowWidth - 1), r.Next(Console.WindowHeight - 1));
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
