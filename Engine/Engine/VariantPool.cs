using System;
using System.Collections.Generic;

namespace Engine
{
	public class VariantPool
	{
		public List<AncSprite> Pool = new List<AncSprite>();

		public void Add(AncSprite sprite)
		{
			Pool.Add(sprite);
		}

		public void Add(params AncSprite[] sprites)
		{
			foreach (var sprite in sprites)
			{
				Pool.Add(sprite);
			}
		}

		public AncSprite Get(int index)
		{
			return Pool[index];
		}

		public AncSprite GetRnd()
		{
			var rnd = new Random();
			return Pool[rnd.Next(0, Pool.Count)];
		}

		public void Delete(int index)
		{
			Pool.Remove(Pool[index]);
		}
	}
}