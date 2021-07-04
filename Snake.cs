using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
	class Snake
	{
		public LinkedList<SnakePart> SnakeParts { get; private set; }

		private SnakePart _head = null;
		public SnakePart Head
		{
			get
			{
				return _head ??= SnakeParts.FirstOrDefault();
			}			
		}

		public void Move(Direction direction)
		{
			foreach (var part in SnakeParts)
			{
				part.XPosition = part.
			}
			SnakeParts.First.Next

			//SnakeParts.First.
		}

		public void Eat(Food food)
		{
			var lastElement = SnakeParts.Last;
			SnakeParts.AddLast(lastElement.Value);
		}
	}
}
