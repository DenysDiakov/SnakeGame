using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
	interface IElement
	{
		public int XPosition { get; set; }

		public int YPosition { get; set; }

		public string Sign { get; set; }
	}
}
