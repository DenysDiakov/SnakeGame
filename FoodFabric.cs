using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
	internal static class FoodFabric
	{
		public static List<Food> Foods { get; }

		static FoodFabric()
		{
			Foods = new List<Food>();
		}

		public static void SpawnFood()
		{
			var freeSpaceCoordinates = Arena.FindFreeSpace();
			var food = new Food(freeSpaceCoordinates);
			Foods.Add(food);
		}

		public static void DeleteFood(Coordinates position)
		{
			var food = Foods.Where(food => food.Coordinates.Equals(position)).FirstOrDefault();
			Foods.Remove(food);
		}
	}
}
