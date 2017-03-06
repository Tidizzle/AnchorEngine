using System;
using System.Collections.Generic;

namespace Engine
{
	public class AncSpritePool
	{
	    private readonly Stack<AncSprite> _pool = new Stack<AncSprite>();

		public void Add(AncSprite sprite)
		{
			_pool.Push(sprite);
		}

		public AncSprite  Rnd()
		{
			var rnd = new Random();

			var i = 0;
			if (_pool.Count != 0)
				i = _pool.Count;

			var selected = rnd.Next(0, i);

			var returner = _pool.Peek();
			for (var cnt = 0; cnt != selected; cnt++)
			{
				returner = _pool.Pop();
			}
			return returner;
		}

		public AncSprite Get()
		{
			return _pool.Pop();
		}


	}
}