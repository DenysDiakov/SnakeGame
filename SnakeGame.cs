using System;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
	class SnakeGame
	{
		public Visualizer Visualizer { get; }

		public SnakeRepository SnakeRepository { get; set; }

		public Snake Snake { get; set; }

		public int Score { get; set; }

		public SnakeGame()
		{
			Visualizer = new Visualizer();
		}

		public void Start()
		{
			SnakeRepository = new SnakeRepository();
			Snake = SnakeRepository.SpawnSnake();
			while (true)
			{
				Console.Clear();
				// Show elements in console
				Visualizer.PrintElement(Arena.AllElements.ToArray());
				Snake.Move();

				var snakeHead = Snake.Head;				
				if (snakeHead.XPosition == Console.WindowWidth)
				{
					snakeHead.XPosition = 0;
				}
				else if (snakeHead.YPosition == Console.WindowHeight)
				{
					snakeHead.YPosition = 0;
				}
				else if (snakeHead.XPosition <= -1)
				{
					snakeHead.XPosition = Console.WindowWidth;
				}
				else if (snakeHead.YPosition <= -1)
				{
					snakeHead.YPosition = Console.WindowHeight;
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
							IncreaseScore(); ;
							break;
						default:
							EndGame();
							return;
					}
				}
				// If snake crash into itself - Game over
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
