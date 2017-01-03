using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test
{
    public class RedBackground : Anchor
    {
        private Texture2D texture;

        public RedBackground(string Name)
        {
            base.Name = Name;
        }

        public override void LoadContent()
        {
            var o = SYSTEM.GraphicsDevice.Viewport.Width;
            var j = SYSTEM.GraphicsDevice.Viewport.Height;
            var k = o * j;

           Color[] ColorData = new Color[1000 * 1000];
            for (int i = 0; i < 100000; i++)
            {
                ColorData[i] = Color.Red;
            }
            texture.SetData(ColorData);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 origin = new Vector2(SYSTEM.GraphicsDevice.Viewport.Width / 2f, SYSTEM.GraphicsDevice.Viewport.Height /2f);
            SYSTEM.SpriteBatch.Draw(texture, origin, Color.White);
        }


        public override void Instantiate(AncSystem sys, AncScene scene)
        {
            SYSTEM = sys;
            texture = new Texture2D(SYSTEM.GraphicsDevice, 500,500);
        }
    }
}