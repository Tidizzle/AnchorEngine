using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
	public class Adam : Anchor
	{
		private AncAnimatedSprite _sprite;
		private int _elapsedupdate;
	    private const int Frametime = 100;

	    private int _starting;
		private int _ending;


		public Adam(string name)
		{
		    Name = name;
		    canMove = true;
		}

		public override void LoadContent()
		{
			_sprite.Texture = SystemRef.Content.Load<Texture2D>("AdamSheetCorners");
			AnchorAniSprite = _sprite;

			GlobalWidth = _sprite.Texture.Width / _sprite.Columns;
			GlobalHeight = _sprite.Texture.Height;
			Scale = new Vector2(2f);

			Location.X = Parent.GraphicsDevice.Viewport.Width / 2 - (int) (GlobalWidth / 2f * Scale.X);
			Location.Y = SystemRef.GraphicsDevice.Viewport.Height / 2 - (int) (GlobalHeight / 2f * Scale.Y);
		}

		public override void Update(GameTime gameTime)
		{
			var deltatime = gameTime.ElapsedGameTime.TotalSeconds;

			AncInput.Update();

		    if (canMove)
		    {
		        if (AncInput.KeyHeld(Keys.A))
		        {
		            _starting = 7;
		            _ending = 13;
		            if (_sprite.Frame < _starting || _sprite.Frame > _ending)
		                _sprite.Frame = _starting;
		            Location.X -= (float) (500 * deltatime);
		        }
		        else if (AncInput.KeyHeld(Keys.D))
		        {
		            _starting = 0;
		            _ending = 6;
		            if (_sprite.Frame < _starting || _sprite.Frame > _ending)
		                _sprite.Frame = _starting;
		            Location.X += (float) (500 * deltatime);
		        }
		        else if (AncInput.KeyHeld(Keys.W))
		        {
		            _starting = 20;
		            _ending = 24;
		            if (_sprite.Frame < _starting || _sprite.Frame > _ending)
		                _sprite.Frame = _starting;
		            Location.Y -= (float) (500 * deltatime);
		        }
		        else if (AncInput.KeyHeld(Keys.S))
		        {
		            _starting = 15;
		            _ending = 19;
		            if (_sprite.Frame < _starting || _sprite.Frame > _ending)
		                _sprite.Frame = _starting;
		            Location.Y += (float) (500 * deltatime);
		        }
		        else
		        {
		            _starting = 14;
		            _ending = 14;
		            _sprite.Frame = 14;
		        }
		    }
		    else
		    {
		        _starting = 14;
		        _ending = 14;
		        _sprite.Frame = 14;
		    }



		    _elapsedupdate += gameTime.ElapsedGameTime.Milliseconds;
			if (_elapsedupdate > Frametime)
			{
				_elapsedupdate = 0;
				_sprite.Frame++;
				if (_sprite.Frame > _ending)
					_sprite.Frame = _starting;
			}

		    if (Location.X < -100)
		        Location.X = -100;

		    if (Location.X > 9700)
		        Location.X = 9700;

		    if (Location.Y < -100)
		        Location.Y = -100;

		    if (Location.Y > 9700)
		        Location.Y = 9700;


		}

		public override void Draw(GameTime gameTime)
		{
			var columnwidth = _sprite.Texture.Width / _sprite.Columns;
			var rowheight = _sprite.Texture.Height / _sprite.Rows;
		    var destrect = new Rectangle
		    {
		        Width = (int) (columnwidth * Scale.X),
		        Height = (int) (rowheight * Scale.Y),
		        X = (int) Location.X,
		        Y = (int) Location.Y
		    };
		    var sourcerect = new Rectangle
		    {
		        Width = columnwidth,
		        Height = rowheight,
		        X = _sprite.Frame * columnwidth,
		        Y = 0
		    };
		    //System.SpriteBatch.Draw(_sprite.Texture, destrect, sourcerect, Color.White, layerDepth: 0.003f);
		    SystemRef.SpriteBatch.Draw(_sprite.Texture, null, destrect, sourcerect, null, 0f, null,Color.White, layerDepth: 0.002f);

		}

		public override void Instantiate(AncSystem sys, AncScene scene)
		{
			SystemRef = sys;
			Parent = scene;
		    _sprite = new AncAnimatedSprite(this, 1, 25) {FileLocation = "AdamSheet"};
		    AnchorAniSprite = _sprite;
		}
	}
}