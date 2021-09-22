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

		static public void SpawnFood()
		{
			int x, y = 0;
			var freePosition = Arena.FindFreeSpace();
			Food food = new Food(freePosition.X, freePosition.Y);
			Foods.Add(food);
		}

		static public void DeleteFood(Position position)
		{
			var food = Foods.Where(food => food.XPosition == position.X && food.YPosition == position.Y).FirstOrDefault();
			Foods.Remove(food);
			food.Sign = string.Empty;
		}
	}
}
