using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test
{
	public class Palm: Anchor
	{
		public Palm(string name)
		{
			this.Name = name;
		}

		public override void LoadContent()
		{
			AnchorSprite.Texture = SYSTEM.Content.Load<Texture2D>(AnchorSprite.fileLocation);
			Scale = new Vector2(7f);
		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(GameTime gameTime)
		{
			SYSTEM.SpriteBatch.Draw(AnchorSprite.Texture, new Vector2(0,0), color: Color.White, scale: Scale);
		}

		public override void Instantiate(AncSystem sys, AncScene scene)
		{
			SYSTEM = sys;
			Parent = scene;

			AnchorSprite = new AncSprite(this);
			AnchorSprite.fileLocation = "Palm";
		}
	}
}