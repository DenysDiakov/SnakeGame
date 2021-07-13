using System;

namespace SnakeGame
{
	class Program
	{
		static void Main(string[] args)
		{
			var settings = new GameSettings("Player 1");
			do
			{
				SnakeGame game = new SnakeGame();
				game.Start(settings);
			}
			while (!Console.ReadKey().Key.Equals(ConsoleKey.Escape));
			
			Console.ReadKey();
		}
	}
}
