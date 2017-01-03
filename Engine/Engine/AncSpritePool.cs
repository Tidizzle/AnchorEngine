using System;
using System.Collections.Generic;
using OpenTK.Platform.Windows;

namespace Engine
{
	public class AncSpritePool
	{
		Stack<AncSprite> Pool = new Stack<AncSprite>();

		public void Add(AncSprite sprite)
		{
			Pool.Push(sprite);
		}

		public AncSprite  Rnd()
		{
			Random rnd = new Random();

			int i = 0;
			if (Pool.Count != 0)
				i = Pool.Count;

			int selected = rnd.Next(0, i);

			AncSprite Returner = Pool.Peek();
			for (int cnt = 0; cnt != selected; cnt++)
			{
				Returner = Pool.Pop();
			}
			return Returner;
		}

		public AncSprite Get()
		{
			return Pool.Pop();
		}


	}
}