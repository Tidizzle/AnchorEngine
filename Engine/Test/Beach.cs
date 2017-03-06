using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test
{
	public class Beach : Anchor
	{
		private AncSprite _sprite;

		public Beach(string name)
		{
			Name = name;
		}

		public override void LoadContent()
		{
			_sprite.Texture = SystemRef.Content.Load<Texture2D>(_sprite.FileLocation);
			AnchorSprite = _sprite;
		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(GameTime gameTime)
		{
			SystemRef.SpriteBatch.Draw(_sprite.Texture, new Vector2(0,0), Color.White);
		}

		public override void Instantiate(AncSystem sys, AncScene scene)
		{
			SystemRef = sys;
		    _sprite = new AncSprite(this) {FileLocation = "beach"};
		    AnchorSprite = _sprite;
		}
	}
}