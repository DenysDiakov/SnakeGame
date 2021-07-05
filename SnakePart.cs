namespace SnakeGame
{
	class SnakePart : IElement
	{
		public int XPosition { get; set; }

		public int YPosition { get; set; }

		public string Sign { get; set; }

		public SnakePart(int x, int y, string sign = "0")
		{
			XPosition = x;
			YPosition = y;
			Sign = sign;
		}
	}
}
