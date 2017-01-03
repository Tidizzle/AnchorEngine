using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
	public class Adam : Anchor
	{
		private AncAnimatedSprite Sprite;
		private int elapsedupdate;
		private readonly int frametime = 100;

		private int starting;
		private int ending;

		public Adam(string Name)
		{
			this.Name = Name;
		}

		public override void LoadContent()
		{
			Sprite.Texture = SYSTEM.Content.Load<Texture2D>(Sprite.FileLocation);
			AnchorAniSprite = Sprite;

			GlobalWidth = Sprite.Texture.Width / Sprite.columns;
			GlobalHeight = Sprite.Texture.Height;
			Scale = new Vector2(5f);

			Location.X = Parent.GraphicsDevice.Viewport.Width / 2 - (int) (GlobalWidth / 2f * Scale.X);
			Location.Y = SYSTEM.GraphicsDevice.Viewport.Height / 2 - (int) (GlobalHeight / 2f * Scale.Y);
		}

		public override void Update(GameTime gameTime)
		{
			var deltatime = gameTime.ElapsedGameTime.TotalSeconds;

			AncInput.Update();

			if (AncInput.KeyHeld(Keys.A))
			{
				starting = 7;
				ending = 13;
				if (Sprite.Frame < starting || Sprite.Frame > ending)
					Sprite.Frame = starting;
				Location.X -= (float) (500 * deltatime);
			}
			else if (AncInput.KeyHeld(Keys.D))
			{
				starting = 0;
				ending = 6;
				if (Sprite.Frame < starting || Sprite.Frame > ending)
					Sprite.Frame = starting;
				Location.X += (float) (500 * deltatime);
			}
			else if (AncInput.KeyHeld(Keys.W))
			{
				starting = 20;
				ending = 24;
				if (Sprite.Frame < starting || Sprite.Frame > ending)
					Sprite.Frame = starting;
				Location.Y -= (float) (500 * deltatime);
			}
			else if (AncInput.KeyHeld(Keys.S))
			{
				starting = 15;
				ending = 19;
				if (Sprite.Frame < starting || Sprite.Frame > ending)
					Sprite.Frame = starting;
				Location.Y += (float) (500 * deltatime);
			}
			else
			{
				starting = 14;
				ending = 14;
				Sprite.Frame = 14;
			}

			elapsedupdate += gameTime.ElapsedGameTime.Milliseconds;
			if (elapsedupdate > frametime)
			{
				elapsedupdate = 0;
				Sprite.Frame++;
				if (Sprite.Frame > ending)
					Sprite.Frame = starting;
			}
		}

		public override void Draw(GameTime gameTime)
		{
			int columnwidth = Sprite.Texture.Width / Sprite.columns;
			int rowheight = Sprite.Texture.Height / Sprite.rows;
			Rectangle destrect = new Rectangle();
			destrect.Width = (int) (columnwidth * Scale.X);
			destrect.Height = (int) (rowheight * Scale.Y);
			destrect.X = (int) Location.X;
			destrect.Y = (int) Location.Y;
			Rectangle sourcerect  = new Rectangle();
			sourcerect.Width = columnwidth;
			sourcerect.Height = rowheight;
			sourcerect.X = Sprite.Frame * columnwidth;
			sourcerect.Y = 0;
			SYSTEM.SpriteBatch.Draw(Sprite.Texture, destrect, sourcerect, Color.White);
		}

		public override void Instantiate(AncSystem sys, AncScene scene)
		{
			SYSTEM = sys;
			Parent = scene;
			Sprite = new AncAnimatedSprite(this,1, 25);
			Sprite.FileLocation = "AdamSheet";
			AnchorAniSprite = Sprite;
		}
	}
}