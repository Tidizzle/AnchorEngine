using System.Collections.Generic;
using Engine;
using Microsoft.Xna.Framework;

namespace Test
{
	public class Scene2 : AncScene
	{
		public Scene2(string name) : base(name)
		{
			Name = name;
		}

		public override void LoadContent()
		{
			foreach (var obj in ObjectList.Values)
			{
				obj.LoadContent();
			}
		}

		public override void Update(GameTime gameTime)
		{
			foreach (var obj in ObjectList.Values)
			{
				obj.Update(gameTime);
			}
		}

		public override void Draw(GameTime gameTime)
		{
			foreach (var obj in ObjectList.Values)
			{
				obj.Draw(gameTime);
			}
		}

		public override void Instantiate(AncSystem sys)
		{
			System = sys;
			ObjectList = new Dictionary<string, Anchor>();
			var bg = new Grassbg("Grass");
			bg.Instantiate(sys, this);
			AddObj(bg);

			var sticky = new Sticky("Sticky");
			sticky.Instantiate(sys, this);
			AddObj(sticky);

			var camera = new Camera(sys.GraphicsDevice, "Camera", sticky);
			camera.Instantiate(sys, this);
			AddObj(camera);
		}
	}
}