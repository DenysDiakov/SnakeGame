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
		public static void FindSpace(out int x, out int y)
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
			x = xCoordinate;
			y = yCoordinate;
		}
	}
}
