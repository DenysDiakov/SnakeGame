using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SnakeGame
{
	class SnakeGame
	{
		public void Start()
		{
			var visualizer = new Visualizer();
			for (int i = 0; i < 30; i++)
			{
				visualizer.WriteAt("0", i, 0);
				Thread.Sleep(100);
			}
		}
	}
}
