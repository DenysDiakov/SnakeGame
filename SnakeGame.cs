using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
	class SnakeGame
	{
		//public Snake Snake { get; set; }

		public Visualizer Visualizer { get; }

		public int Score { get; set; }

		public SnakeRepository SnakeRepository { get; set; }

		public const int Speed = 66;

		public SnakeGame()
		{
			SnakeRepository = new SnakeRepository();
			//Snake = new Snake();
			Visualizer = new Visualizer();
		}

		public void UpdateConsole()
		{
			while (true)
			{
				Console.Clear();
				Visualizer.PrintElement(Arena.AllElements.ToArray());
				Thread.Sleep(30);
			}
		}

		static object obj = new object();
		void handleWithSnakeUpdates(Snake snake)
		{
			if (Console.KeyAvailable)
			{
				var key = Console.ReadKey(true).Key;
				switch (key)
				{
					case ConsoleKey.UpArrow:
					case ConsoleKey.W:
						snake.ChangeDirection(Direction.Up);
						break;
					case ConsoleKey.RightArrow:
					case ConsoleKey.D:
						snake.ChangeDirection(Direction.Right);
						break;
					case ConsoleKey.DownArrow:
					case ConsoleKey.S:
						snake.ChangeDirection(Direction.Down);
						break;
					case ConsoleKey.LeftArrow:
					case ConsoleKey.A:
						snake.ChangeDirection(Direction.Left);
						break;
					case ConsoleKey.Spacebar:
						snake.AddBodyPart();
						++Score;
						break;
					default:
						EndGame();
						return;
				}
			}
		}

		public void Start(GameSettings settings)
		{
			SnakeRepository.SpawnSnake();
			SnakeRepository.SpawnSnake();

			//var snake = SnakeRepository.SpawnSnake();
			//var snake2 = SnakeRepository.SpawnSnake();

			//Task.Run(() => StartSnakeProcess(snake, true));

			//Task.Run(() => StartSnakeProcess(snake2));
			//Task.Run(UpdateConsole);
			//	Remove while true
			while (true)
			{
				Console.Clear();
				// Show elements in console
				Visualizer.PrintElement(Arena.AllElements.ToArray());
				SnakeRepository.Move();
				foreach (var snake in SnakeRepository.Snakes)
				{
					int headXPosition = snake.Head.XPosition;
					int headYPosition = snake.Head.YPosition;

					//int headXPosition = snake.Head.XPosition;
					//int headYPosition = snake.Head.YPosition;
					if (snake.Head.XPosition == Console.WindowWidth)
					{
						snake.Head.XPosition = 0;
					}
					if (snake.Head.YPosition == Console.WindowHeight)
					{
						snake.Head.YPosition = 0;
					}
					if (snake.Head.XPosition <= -1)
					{
						snake.Head.XPosition = Console.WindowWidth;
					}
					if (snake.Head.YPosition <= -1)
					{
						snake.Head.YPosition = Console.WindowHeight;
					}
				}
				//foreach (var snake in SnakeRepository.Snakes)
				//{
				//	Task.Run(() => handleWithSnakeUpdates(snake));
				//}
				if (Console.KeyAvailable)
				{
					var key = Console.ReadKey(true).Key;
					var key2 = Console.ReadKey(true);

					var cin = Console.In;

					switch (key)
					{
						case ConsoleKey.UpArrow:
							SnakeRepository.Snakes.FirstOrDefault().ChangeDirection(Direction.Up);
							break;
						case ConsoleKey.W:
							SnakeRepository.Snakes.LastOrDefault().ChangeDirection(Direction.Up);
							break;
						case ConsoleKey.RightArrow:
							SnakeRepository.Snakes.FirstOrDefault().ChangeDirection(Direction.Right);
							break;
						case ConsoleKey.D:
							SnakeRepository.Snakes.LastOrDefault().ChangeDirection(Direction.Right);
							break;
						case ConsoleKey.DownArrow:
							SnakeRepository.Snakes.FirstOrDefault().ChangeDirection(Direction.Down);
							break;
						case ConsoleKey.S:
							SnakeRepository.Snakes.LastOrDefault().ChangeDirection(Direction.Down);
							break;
						case ConsoleKey.LeftArrow:
							SnakeRepository.Snakes.FirstOrDefault().ChangeDirection(Direction.Left);
							break;
						case ConsoleKey.A:
							SnakeRepository.Snakes.LastOrDefault().ChangeDirection(Direction.Left);
							break;
						case ConsoleKey.Spacebar:
							SnakeRepository.Snakes.FirstOrDefault().AddBodyPart();
							++Score;
							break;
						default:
							EndGame();
							return;
					}
				}

				// If snake crash into itself - Game over
				if (SnakeRepository.Snakes.Any(x => x.SnakeParts.Count > 3) && !SnakeRepository.SnakesIsAlive())
				{
					EndGame();
					return;
				}
				if (FoodFabric.Foods.Count < 2)
				{
					FoodFabric.SpawnFood();
				}
				if (SnakeRepository.IsSnakesOnFood())
				{
					var snakesToUpdate = SnakeRepository.GetOnFoodSnakes();
					snakesToUpdate.ForEach(x => { x.Eat(); x.Player.Score++; });
				}
				Thread.Sleep(Speed);
			}
		}

		public void StartSnakeProcess(Snake snake, bool mainSnake = false)
		{
			// Remove while true
			while (true)
			{
				if (mainSnake)
				{
					Console.Clear();
					Visualizer.PrintElement(Arena.AllElements.ToArray());
				}
				// Show elements in console
				snake.Move();
				int headXPosition = snake.Head.XPosition;
				int headYPosition = snake.Head.YPosition;

				if (snake.Head.XPosition == Console.WindowWidth)
				{
					snake.Head.XPosition = 0;
				}
				if (snake.Head.YPosition == Console.WindowHeight)
				{
					snake.Head.YPosition = 0;
				}
				if (snake.Head.XPosition <= -1)
				{
					snake.Head.XPosition = Console.WindowWidth;
				}
				if (snake.Head.YPosition <= -1)
				{
					snake.Head.YPosition = Console.WindowHeight;
				}
				if (Console.KeyAvailable)
				{
					var key = Console.ReadKey(true).Key;
					switch (key)
					{
						case ConsoleKey.UpArrow:
						case ConsoleKey.W:
							snake.ChangeDirection(Direction.Up);
							break;
						case ConsoleKey.RightArrow:
						case ConsoleKey.D:
							snake.ChangeDirection(Direction.Right);
							break;
						case ConsoleKey.DownArrow:
						case ConsoleKey.S:
							snake.ChangeDirection(Direction.Down);
							break;
						case ConsoleKey.LeftArrow:
						case ConsoleKey.A:
							snake.ChangeDirection(Direction.Left);
							break;
						case ConsoleKey.Spacebar:
							snake.AddBodyPart();
							++Score;
							break;
						default:
							EndGame();
							return;
					}
				}

				// If snake crash into itself - Game over
				if (SnakeRepository.Snakes.Any(x => x.SnakeParts.Count > 3) && !SnakeRepository.SnakesIsAlive())
				{
					EndGame();
					return;
				}

				if (FoodFabric.Foods.Count < 2)
				{
					FoodFabric.SpawnFood();
				}
				if (snake.IsSnakeOnFood())
				{
					snake.Eat();
					snake.Player.Score++;
				}
				Thread.Sleep(30);
			}
		}

		public void EndGame()
		{
			Console.Clear();
			Console.SetCursorPosition(Console.WindowWidth / 3, Console.WindowHeight / 2);
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
