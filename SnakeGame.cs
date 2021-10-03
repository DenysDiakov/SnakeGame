using System;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
	public class SnakeGame
	{
		public SnakeRepository SnakeRepository { get; private set; }

		public Snake Snake { get; private set; }

		public int Score { get; private set; }

		public void Start()
		{
			SnakeRepository = new SnakeRepository();
			Snake = SnakeRepository.SpawnSnake();
			while (true)
			{
				Console.Clear();
				Visualizer.PrintElements(Arena.AllElements.ToArray());
				Snake.Move();

				var snakeHead = Snake.Head;
				var headPosition = snakeHead.Coordinates;
				if (headPosition.X == Console.WindowWidth)
				{
					snakeHead.Coordinates = new Coordinates(0, headPosition.Y);
				}
				else if (headPosition.Y == Console.WindowHeight)
				{
					snakeHead.Coordinates = new Coordinates(headPosition.X, 0);
				}
				else if (headPosition.X <= -1)
				{
					snakeHead.Coordinates = new Coordinates(Console.WindowWidth, headPosition.Y);
				}
				else if (headPosition.Y <= -1)
				{
					snakeHead.Coordinates = new Coordinates(headPosition.X, Console.WindowHeight);
				}
				if (Console.KeyAvailable)
				{
					var key = Console.ReadKey().Key;
					switch (key)
					{
						case ConsoleKey.UpArrow:
							Snake.ChangeDirection(Direction.Up);
							break;
						case ConsoleKey.RightArrow:
							Snake.ChangeDirection(Direction.Right);
							break;
						case ConsoleKey.DownArrow:
							Snake.ChangeDirection(Direction.Down);
							break;
						case ConsoleKey.LeftArrow:
							Snake.ChangeDirection(Direction.Left);
							break;
						case ConsoleKey.Spacebar:
							Snake.AddBodyPart();
							IncreaseScore();
							break;
						default:
							EndGame();
							return;
					}
				}
				if (Snake.SnakeParts.Count > 3 && Snake.IsDead())
				{
					EndGame();
					return;
				}
				if (FoodFabric.Foods.Count < 1)
				{
					FoodFabric.SpawnFood();
				}
				if (Snake.IsOnFood())
				{
					Snake.Eat();
					IncreaseScore();
				}
				Thread.Sleep(30);
			}
		}

		public void IncreaseScore()
		{
			++Score;
		}

		public void EndGame()
		{
			Console.Clear();
			Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
			Console.WriteLine($"Game Over with score {Score} !");
		}
	}
}
