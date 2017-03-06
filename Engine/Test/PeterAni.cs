using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    public class PeterAni : Anchor
    {
        private AncAnimatedSprite _sprite;
        private int _elapsedupdate;
        private const int Frametime = 100;

        private int _starting;
        private int _ending;

        public PeterAni(string name)
        {
            Name = name;


        }

        public override void LoadContent()
        {

	        _sprite.Texture = SystemRef.Content.Load<Texture2D>(_sprite.FileLocation);
            AnchorAniSprite = _sprite;

	        GlobalWidth = _sprite.Texture.Width / _sprite.Columns;
	        GlobalHeight = _sprite.Texture.Height;
	        Scale = new Vector2(10f);

	        Location.X = Parent.GraphicsDevice.Viewport.Width / 2 - (int) (GlobalWidth / 2f * Scale.X);
	        Location.Y = SystemRef.GraphicsDevice.Viewport.Height / 2 -  (int) (GlobalHeight / 2f * Scale.Y);
        }

        public override void Update(GameTime gameTime)
        {
	        var deltatime = gameTime.ElapsedGameTime.TotalSeconds;

            AncInput.Update();

            if (AncInput.KeyHeld(Keys.A))
            {
                _starting = 4;
                _ending = 7;
                if (_sprite.Frame < _starting || _sprite.Frame > _ending)
                {
                    _sprite.Frame = _starting;
                }
                Location.X -= (float) ( 500 * deltatime);
            }
            else if (AncInput.KeyHeld(Keys.D))
            {
                _starting = 0;
                _ending = 3;
                if ( _sprite.Frame < _starting || _sprite.Frame > _ending)
                {
                    _sprite.Frame = _starting;
                }
                Location.X += (float)(500 * deltatime);
            }
            else if (AncInput.KeyHeld(Keys.W))
            {
                _starting = 8;
                _ending = 10;
                if (_sprite.Frame < _starting || _sprite.Frame > _ending)
                {
                    _sprite.Frame = _starting;
                }
                Location.Y -= (float)( 500 * deltatime);
            }
            else if (AncInput.KeyHeld(Keys.S))
            {
                _starting = 11;
                _ending = 14;
                if (_sprite.Frame < _starting || _sprite.Frame > _ending)
                {
                    _sprite.Frame = _starting;
                }
                Location.Y += (float) (500  * deltatime);
            }
            else if (AncInput.KeyHeld(Keys.LeftControl))
            {
                _starting = 16;
                _ending = 16;
                if (_sprite.Frame < _starting || _sprite.Frame > _ending)
                {
                    _sprite.Frame = _starting;
                }
            }
            else if (AncInput.KeyUp(Keys.LeftControl))
            {
                _starting = 15;
                _ending = 17;
                if (_sprite.Frame < _starting || _sprite.Frame > _ending)
                {
                    _sprite.Frame = _starting;
                }
            }
            else
            {
                _starting = 11;
                _ending = 11;
                _sprite.Frame = 11;
            }



            _elapsedupdate += gameTime.ElapsedGameTime.Milliseconds;
	        if (_elapsedupdate > Frametime)
	        {
		        _elapsedupdate = 0;

		        _sprite.Frame++;
		        if (_sprite.Frame > _ending)
		        {
			        _sprite.Frame = _starting;
		        }
	        }
        }

        public override void Draw(GameTime gameTime)
        {

            var columnwidth = _sprite.Texture.Width / _sprite.Columns;
            var rowheight = _sprite.Texture.Height / _sprite.Rows;

            var destrect = new Rectangle
            {
                Width = columnwidth * 10,
                Height = rowheight * 10,
                X = (int) Location.X,
                Y = (int) Location.Y
            };

            var sourcerect = new Rectangle
            {
                Width = _sprite.Texture.Width / _sprite.Columns,
                Height = _sprite.Texture.Height / _sprite.Rows,
                X = _sprite.Frame * columnwidth,
                Y = 0
            };

            SystemRef.SpriteBatch.Draw(_sprite.Texture, destrect, sourcerect, Color.White);
        }

        public override void Instantiate(AncSystem sys, AncScene scene)
        {
            SystemRef = sys;
            _sprite = new AncAnimatedSprite(this, 1, 18) {FileLocation = "peterspritesheet"};
            AnchorAniSprite = _sprite;
            Parent = scene;


        }
    }
}

