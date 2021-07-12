using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
	class Arena
	{
		public static IEnumerable<IElement> AllElements
		{
			get
			{
				return SnakeRepository.Snakes.SelectMany(x => x.SnakeParts).ToList<IElement>().Concat(FoodFabric.Foods);
			}
		}

		public static void FindSpace()
		{

		}
	}
}
