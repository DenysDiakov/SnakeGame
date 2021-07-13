using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
	class Snake
	{
		public List<SnakePart> SnakeParts { get; private set; }

		public Direction CurrentDirection { get; set; }

		private SnakePart _head = null;
		public SnakePart Head
		{
			get
			{
				return _head ??= SnakeParts.FirstOrDefault();
			}			
		}

		// Add parameters
		public Snake()
		{
			CurrentDirection = Direction.Right;
			SnakeParts = new List<SnakePart>();

			int x = Console.WindowHeight - 1;
			int y = 10;
			var head = new SnakePart(x, y, "G") { Color = ConsoleColor.DarkGreen };
			SnakeParts.Add(head);
			SnakeParts.Add(new SnakePart(x + 1, y));
		}

		public void Move()
		{
			// Snake tail. Each elements takes the place of the next
			for (int i = SnakeParts.Count - 1; i > 0; i--)
			{
				var previousPart = SnakeParts[i];
				if (previousPart.Equals(Head))
				{
					break;
				}
				var nextPart = SnakeParts[i - 1];
				previousPart.XPosition = nextPart.XPosition;
				previousPart.YPosition = nextPart.YPosition;
			}

			switch (CurrentDirection)
			{
				case Direction.Up:
					--Head.YPosition;
					break;
				case Direction.Right:
					++Head.XPosition;
					break;
				case Direction.Down:
					++Head.YPosition;
					break;
				case Direction.Left:
					--Head.XPosition;
					break;				
			}						
		}

		public void ChangeDirection(Direction direction)
		{
			CurrentDirection = direction;
		}

		public void Eat()
		{
			FoodFabric.DeleteFood(Head.XPosition, Head.YPosition);
			AddBodyPart();
		}

		public void AddBodyPart()
		{
			var lastPart = SnakeParts.LastOrDefault();

			int x = lastPart.XPosition;
			int y = lastPart.YPosition;

			switch (CurrentDirection)
			{
				case Direction.Up:
					--y;
					break;
				case Direction.Right:
					++x;
					break;
				case Direction.Down:
					++y;
					break;
				case Direction.Left:
					--x;
					break;
			}

			SnakeParts.Add(new SnakePart(x, y)
			{ 
				Color = SnakeParts.Count % 2 == 0 ? ConsoleColor.Yellow : ConsoleColor.Green 
			});
		}

		public bool IsAlive()
		{
			return !SnakeParts.Where(x => x != Head).Any(x => x.XPosition == Head.XPosition && x.YPosition == Head.YPosition);
		}

		public bool IsSnakeOnFood()
		{
			return FoodFabric.Foods.Any(x => x.XPosition == Head.XPosition && x.YPosition == Head.YPosition);
		}
	}
}
