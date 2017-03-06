using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    public class Peter : Anchor
    {
        private AncSprite _sprite;
        private readonly Vector2 _scale = new Vector2(10f);
        private Vector2 _location;
        private Vector2 _origin;
        private SpriteEffects _effect;

        public Peter(string name)
        {
            Name = name;
        }

        public override void LoadContent()
        {
            _sprite.Texture = SystemRef.Content.Load<Texture2D>(_sprite.FileLocation);
            AnchorSprite = _sprite;

            _location.X = SystemRef.GraphicsDevice.Viewport.Width / 2f;
            _location.Y = SystemRef.GraphicsDevice.Viewport.Height / 2f;
            _origin.X = _sprite.Texture.Width / 2f;
            _origin.Y = _sprite.Texture.Height / 2f;

        }

        public override void Update(GameTime gameTime)
        {
            AncInput.Update();

            if (AncInput.KeyHeld(Keys.A) || AncInput.KeyDown(Keys.A))
            {
                _effect = SpriteEffects.FlipHorizontally;

                _location += new Vector2(-5,0);
            }

            if (AncInput.KeyDown(Keys.D) || AncInput.KeyHeld(Keys.D))
            {
                _effect = SpriteEffects.None;

                _location += new Vector2(5, 0);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            SystemRef.SpriteBatch.Draw(_sprite.Texture, _location, color: Color.White, scale: _scale, origin: _origin, effects: _effect);
        }


        public override void Instantiate(AncSystem sys, AncScene scene)
        {
            SystemRef = sys;
            _sprite = new AncSprite(this) {FileLocation = "peter"};
            AnchorSprite = _sprite;

        }
    }
}