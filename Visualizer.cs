using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
	class Visualizer
    {
        public Visualizer()
		{
            Console.CursorVisible = false;
            Console.SetWindowSize(55, 25);
		}

        public void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

   //     public void PrintSnake(Snake snake)
   //     {
   //         foreach (var part in snake.SnakeParts)
			//{
   //             WriteAt(part.Sign, part.XPosition, part.YPosition);
			//}
   //     }

        public void PrintElement(/*IList<IElement>*/ params IElement[] element)
        {
			foreach (var e in element)
			{
                WriteAt(e.Sign, e.XPosition, e.YPosition);
			}
        }
    }
}
