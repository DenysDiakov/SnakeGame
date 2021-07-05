using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
	class Food : IElement
	{
		public int XPosition { get; set; }

		public int YPosition { get; set; }

		public string Sign { get; set; }

		public Food(int x, int y)
		{
			XPosition = x;
			YPosition = y;
			Sign = "@";
		}
	}
}
