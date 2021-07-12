using System;

namespace SnakeGame
{
	class Program
	{
		static void Main(string[] args)
		{
			SnakeGame game = new SnakeGame();
			var settings = new GameSettings("Player 1");
			game.Start(settings);
			Console.ReadKey();
		}
	}
}
