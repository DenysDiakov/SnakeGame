using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
	public class Snake
	{
		public List<SnakePart> SnakeParts { get; private set; }

		public Direction CurrentDirection { get; private set; }

		private SnakePart _head = null;
		public SnakePart Head
		{
			get
			{
				return _head ??= SnakeParts.FirstOrDefault();
			}			
		}

		public Snake()
		{
			CurrentDirection = Direction.Right;
			SnakeParts = new List<SnakePart>();

			var coordinates = new Coordinates(Console.WindowHeight - 1, 10);
			var head = new SnakePart(coordinates, "G") { Color = ConsoleColor.DarkGreen };
			SnakeParts.Add(head);
			++coordinates.X;
			SnakeParts.Add(new SnakePart(coordinates));
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
				previousPart.Coordinates = nextPart.Coordinates;
			}

			changeCoordinates(Head);						
		}

		private void changeCoordinates(SnakePart snakePart)
		{
			int x = snakePart.Coordinates.X;
			int y = snakePart.Coordinates.Y;
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
			snakePart.Coordinates = new Coordinates(x, y);
		}


		public void ChangeDirection(Direction direction)
		{
			CurrentDirection = direction;
		}

		public void Eat()
		{
			FoodFabric.DeleteFood(Head.Coordinates);
			AddBodyPart();
		}

		public void AddBodyPart()
		{
			var lastPart = SnakeParts.LastOrDefault();			
			changeCoordinates(lastPart);
			SnakeParts.Add(new SnakePart(lastPart.Coordinates)
			{ 
				Color = SnakeParts.Count % 2 == 0 ? ConsoleColor.Yellow : ConsoleColor.Green 
			});
		}

		public bool IsDead()
		{
			return SnakeParts.Where(snakePart => snakePart != Head).Any(snakePart => snakePart.Coordinates.Equals(Head.Coordinates));
		}

		public bool IsOnFood()
		{
			return FoodFabric.Foods.Any(food => food.Coordinates.Equals(Head.Coordinates));
		}
	}
}
