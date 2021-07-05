using System;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
	class SnakeGame
	{
		public Snake Snake { get; }

		public Visualizer Visualizer { get; }

		public int Score { get; set; }

		public SnakeGame()
		{
			Snake = new Snake();
			Visualizer = new Visualizer();
		}

		public void Start()
		{
			while (true)
			{
				Console.Clear();
				// Отоьразить элементы в консоли
				var screenElements = Snake.SnakeParts.Union(FoodFabric.Foods).ToArray();
				Visualizer.PrintElement(screenElements);
				Snake.Move();
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
							++Score;
							break;
						default:
							EndGame();
							return;
					}
				}
				// Если змейка врежеться сама в себя - конец игры
				if (Snake.SnakeParts.Count > 3 && !Snake.IsAlive())
				{
					EndGame();
					return;
				}
				if (FoodFabric.Foods.Count < 1)
				{
					FoodFabric.SpawnFood(Snake.SnakeParts);
				}
				if (Snake.IsSnakeOnFood())
				{
					Snake.Eat();
					++Score;
				}
				Thread.Sleep(30);
			}
		}

		public void EndGame()
		{
			Console.Clear();
			Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
			Console.WriteLine($"Game Over with score {Score} !");
		}	
	}
}
