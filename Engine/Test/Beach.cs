using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test
{
	public class Beach : Anchor
	{
		private AncSprite Sprite;

		public Beach(string name)
		{
			Name = name;
		}

		public override void LoadContent()
		{
			Sprite.Texture = SYSTEM.Content.Load<Texture2D>(Sprite.fileLocation);
			AnchorSprite = Sprite;
		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(GameTime gameTime)
		{
			SYSTEM.SpriteBatch.Draw(Sprite.Texture, new Vector2(0,0), Color.White);
		}

		public override void Instantiate(AncSystem sys, AncScene scene)
		{
			SYSTEM = sys;
			Sprite = new AncSprite(this);
			Sprite.fileLocation = "beach";
			AnchorSprite = Sprite;
		}
	}
}