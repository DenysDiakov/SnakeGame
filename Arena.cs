using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
	internal static class Arena
	{
		/// <summary>
		/// All elements on the arena
		/// </summary>
		public static IEnumerable<IElement> AllElements
		{
			get
			{
				return SnakeRepository.Snakes.SelectMany(x => x.SnakeParts).Cast<IElement>().Concat(FoodFabric.Foods);
			}
		}

		/// <summary>
		/// Find free space on the arena
		/// </summary>
		/// <param name="x">X coordinate</param>
		/// <param name="y">Y coordinate</param>
		public static Coordinates FindFreeSpace()
		{
			Random r = new Random();
			Coordinates freePosition;
			do
			{
				freePosition = new Coordinates(r.Next(Console.WindowWidth - 1), r.Next(Console.WindowHeight - 1));
			}
			while (AllElements.Any(element => element.Coordinates.Equals(freePosition)));
			return freePosition;			
		}
	}

	public struct Coordinates
	{
		public int X { get; set; }

		public int Y { get; set; }

		public Coordinates(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
