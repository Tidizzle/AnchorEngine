using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    public class Sticky : Anchor
    {

        private AncSprite _sprite;
        private readonly Vector2 _scale = new Vector2(0);
        private Vector2 _origin;
        private Vector2 _location;

        public Sticky(string name)
        {
            Name = name;
        }

        public override void LoadContent()
        {
            var loc = _sprite.FileLocation;
            _sprite.Texture = SystemRef.Content.Load<Texture2D>(loc);

            _origin.X = _sprite.Texture.Width / 2f;
            _origin.Y = _sprite.Texture.Height / 2f;
            _location.X = SystemRef.GraphicsDevice.Viewport.Width / 4f;
            _location.Y = SystemRef.GraphicsDevice.Viewport.Height / 4f;
        }

        public override void Update(GameTime gameTime)
        {

            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
            {
                SystemRef.Exit();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            SystemRef.SpriteBatch.Draw(_sprite.Texture,_location, color: Color.White, scale: _scale, origin: _origin);
        }


        public override void Instantiate(AncSystem sys, AncScene scene)
        {
            SystemRef = sys;
            _sprite = new AncSprite(this) {FileLocation = "stickdude"};
            AnchorSprite = _sprite;
        }
    }
}