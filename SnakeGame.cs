using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
	class SnakeGame
	{
		public Snake Snake { get; set; }

		public Visualizer Visualizer { get; }

		public int Score { get; set; }

		public SnakeRepository SnakeRepository { get; set; }

		public SnakeGame()
		{
			SnakeRepository = new SnakeRepository();
			//Snake = new Snake();
			Visualizer = new Visualizer();
		}

		public void Start(GameSettings settings)
		{
			SnakeRepository.SpawnSnake();
			// temp
			Snake = SnakeRepository.Snakes.FirstOrDefault();
			while (true)
			{
			
				Console.Clear();
				// Отоьразить элементы в консоли
				//var screenElements = Snake.SnakeParts.Union(FoodFabric.Foods).ToArray();
				Visualizer.PrintElement(Arena.AllElements.ToArray());
				Snake.Move();
				if (Snake.Head.XPosition == Console.WindowWidth)
				{
					EndGame();
					return;
				}
				if (Snake.Head.YPosition == Console.WindowHeight)
				{
					EndGame();
					return;
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

						case ConsoleKey.W:


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

	class GameSettings
	{
		//private int _playersAmount;
		//public int PlayerAmount 
		//{
		//	get
		//	{
		//		return _playersAmount = Players.Count;
		//	}
		//}

		//public int PlayerAmount { get => Players.Count; }

		public List<Player> Players { get; set; }

		public GameSettings(string name)
		{
			Players = new List<Player>();
			addPlayer(name);
		}

		public GameSettings(string p1, string p2) : this(p1)
		{
			addPlayer(p2);
		}

		private void addPlayer(string name) 
		{
			Players.Add(new Player(name));
		}
	}

	class Player
	{
		public string Name { get; set; }

		public int Score { get; set; }

		public Player(string name)
		{
			Name = name;
		}
	}
}
