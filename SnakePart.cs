using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
	class SnakePart : IPosition
	{
		public int XPosition { get; set; }

		public int YPosition { get; set; }

		public SnakePart(int x, int y)
		{
			XPosition = x;
			YPosition = y;
		}
	}
}
