using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test
{
	public class Palm: Anchor
	{
		public Palm(string name)
		{
			Name = name;
		}

		public override void LoadContent()
		{
			AnchorSprite.Texture = SystemRef.Content.Load<Texture2D>(AnchorSprite.FileLocation);
			Scale = new Vector2(4f);
		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(GameTime gameTime)
		{
			SystemRef.SpriteBatch.Draw(AnchorSprite.Texture, new Vector2(0,0), color: Color.White, scale: Scale, layerDepth:0.004f);
		}

		public override void Instantiate(AncSystem sys, AncScene scene)
		{
			SystemRef = sys;
			Parent = scene;

		    AnchorSprite = new AncSprite(this) {FileLocation = "CollisionTest"};
		}
	}
}