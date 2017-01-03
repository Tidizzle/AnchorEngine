using System.Collections.Generic;
using System.Runtime.Serialization;
using Engine;
using Microsoft.Xna.Framework;

namespace Test
{
	public class Scene2 : AncScene
	{
		public Scene2(string Name) : base(Name)
		{
			base.Name = Name;
		}

		public override void LoadContent()
		{
			foreach (var obj in objectList.Values)
			{
				obj.LoadContent();
			}
		}

		public override void Update(GameTime gameTime)
		{
			foreach (var obj in objectList.Values)
			{
				obj.Update(gameTime);
			}
		}

		public override void Draw(GameTime gameTime)
		{
			foreach (var obj in objectList.Values)
			{
				obj.Draw(gameTime);
			}
		}

		public override void Instantiate(AncSystem sys)
		{
			SYSTEM = sys;
			objectList = new Dictionary<string, Anchor>();
			var bg = new Grassbg("Grass");
			bg.Instantiate(sys, this);
			addObj(bg);

			var sticky = new sticky("Sticky");
			sticky.Instantiate(sys, this);
			addObj(sticky);

			var camera = new Engine.Camera(sys.GraphicsDevice, "Camera", sticky);
			camera.Instantiate(sys, this);
			addObj(camera);
		}
	}
}