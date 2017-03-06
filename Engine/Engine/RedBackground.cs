using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class RedBackground : Anchor
    {
        private Texture2D _texture;

        public RedBackground(string name)
        {
            Name = name;
        }

        public override void LoadContent()
        {
           var colorData = new Color[1000 * 1000];
            for (var i = 0; i < 100000; i++)
            {
                colorData[i] = Color.Red;
            }
            _texture.SetData(colorData);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            var origin = new Vector2(SystemRef.GraphicsDevice.Viewport.Width / 2f, SystemRef.GraphicsDevice.Viewport.Height /2f);
            SystemRef.SpriteBatch.Draw(_texture, origin, Color.White);
        }


        public override void Instantiate(AncSystem sys, AncScene scene)
        {
            SystemRef = sys;
            _texture = new Texture2D(SystemRef.GraphicsDevice, 500,500);
        }
    }
}