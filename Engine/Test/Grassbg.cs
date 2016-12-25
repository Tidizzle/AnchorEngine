using System;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test
{
    public class Grassbg  : Anchor
    {
        private AncSprite Sprite;

        public Grassbg(string name)
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
            int x = SYSTEM.Graphics.PreferredBackBufferWidth;
            int y = SYSTEM.Graphics.PreferredBackBufferHeight;
            int width = Sprite.Texture.Width;
            int height = Sprite.Texture.Height;
            int columns = x / width + 1;
            int rows = y / height + 1;
            int cells = rows * columns;
            int current = 0;

            for (int i = 0; i < cells; i++)
            {
                int row = current / columns;
                int column = current % columns;

                int vecx = width * column;
                int vecy = height * row;

                SYSTEM.SpriteBatch.Draw(Sprite.Texture, new Vector2((float) vecx, (float) vecy), Color.White);
                current++;
            }

        }

        public override void Instantiate(AncSystem sys)
        {
            SYSTEM = sys;
            Sprite = new AncSprite(this);
            Sprite.fileLocation = "grass";
            AnchorSprite = Sprite;
        }
    }
}