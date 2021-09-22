using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
	class Arena
	{
		/// <summary>
		/// All elements on the arena
		/// </summary>
		public static IEnumerable<IElement> AllElements
		{
			get
			{
				return SnakeRepository.Snakes.SelectMany(x => x.SnakeParts).ToList<IElement>().Concat(FoodFabric.Foods);
			}
		}

		/// <summary>
		/// Find free space on the arena
		/// </summary>
		/// <param name="x">X coordinate</param>
		/// <param name="y">Y coordinate</param>
		public static Position FindFreeSpace()
		{
			Random r = new Random();
			int xCoordinate = 0;
			int yCoordinate = 0;
			do
			{
				xCoordinate = r.Next(Console.WindowWidth - 1);
				yCoordinate = r.Next(Console.WindowHeight - 1);
			}
			while (AllElements.Any(s => s.XPosition == xCoordinate && s.YPosition == yCoordinate));
			return new Position(xCoordinate, yCoordinate);			
		}
	}

	public class Position
	{
		public int X { get; set; }

		public int Y { get; set; }

		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
