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

		public const int Speed = 66;

		public SnakeGame()
		{
			SnakeRepository = new SnakeRepository();
			//Snake = new Snake();
			Visualizer = new Visualizer();
		}

		public void Start(GameSettings settings)
		{
			SnakeRepository.SpawnSnake();
			SnakeRepository.SpawnSnake();

			// temp
			//Snake = SnakeRepository.Snakes.FirstOrDefault();

			// Remove while true
			while (true)
			{
				Console.Clear();
				// Show elements in console
				Visualizer.PrintElement(Arena.AllElements.ToArray());
				SnakeRepository.Move();

				var snakes = Arena.AllElements
			   .Where(x => x.GetType().Equals(typeof(SnakePart)));

				var gr = Arena.AllElements.ToLookup(x => x.GetType());

				foreach (var snake in SnakeRepository.Snakes)
				{
					int headXPosition = snake.Head.XPosition;
					int headYPosition = snake.Head.YPosition;
					//if (headXPosition == Console.WindowWidth ||
					//	headYPosition == Console.WindowHeight ||
					//	headXPosition <= -2 ||
					//	headYPosition <= -2)
					//{
					//	EndGame();
					//	return;
					//}
					//Console.WriteLine("x = " + headXPosition + "y = " + headYPosition);

					//int headXPosition = snake.Head.XPosition;
					//int headYPosition = snake.Head.YPosition;
					if (snake.Head.XPosition == Console.WindowWidth )
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
				
				if (Console.KeyAvailable)
				{
					var key = Console.ReadKey(true).Key;
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
				if (/*SnakeRepository.Snakes.Any(x => x.SnakeParts.Count > 3) &&*/ !SnakeRepository.SnakesIsAlive())
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
					snakesToUpdate.ForEach(x => x.Eat());
					++Score;
				}
				Thread.Sleep(Speed);
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
