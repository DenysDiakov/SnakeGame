using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SnakeGame
{
	class SnakeGame
	{
		public Snake Snake { get; }

		public Visualizer Visualizer { get; }

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
				// Print snake
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
							break;
						default:
							EndGame();
							return;
					}
				}
				// if snake hit yourself - game over
				if (Snake.SnakeParts.Count > 3 && !Snake.IsAlive())
				{
					EndGame();
					return;
				}
				if (FoodFabric.Foods.Count < 1)
				{
					FoodFabric.SpawnFood();
				}
				if (Snake.IsSnakeOnFood())
				{
					Snake.Eat();
				}
				Thread.Sleep(30);
			}
		}

		public void EndGame()
		{
			Console.Clear();
			Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
			Console.WriteLine("Game Over!");
		}	
	}
}
