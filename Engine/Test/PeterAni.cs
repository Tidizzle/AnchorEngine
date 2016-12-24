using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    public class PeterAni : Anchor
    {
        private AncAnimatedSprite Sprite;
        private readonly Vector2 Scale = new Vector2(10f);
        private Vector2 location;
        private Vector2 origin;
        private SpriteEffects effect;

        public PeterAni(string name)
        {
            Name = name;
        }

        public override void LoadContent()
        {
            Sprite.Texture = SYSTEM.Content.Load<Texture2D>(Sprite.FileLocation);
            AnchorAniSprite = Sprite;

            location.X = SYSTEM.GraphicsDevice.Viewport.Width / 2f;
            location.Y = SYSTEM.GraphicsDevice.Viewport.Height / 2f;
            origin.X = Sprite.Texture.Width / 2f;
            origin.Y = Sprite.Texture.Height / 2f;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Frame++;
            if (Sprite.Frame > Sprite.Frames)
                Sprite.Frame = 0;

            if (AncInput.KeyHeld(Keys.A) || AncInput.KeyDown(Keys.A))
            {
                effect = SpriteEffects.FlipHorizontally;

                location += new Vector2(-5,0);
            }

            if(AncInput.KeyDown(Keys.D) || AncInput.KeyHeld(Keys.D))
            {
                effect = SpriteEffects.None;

                location += new Vector2(5,0);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            int Width = Sprite.Texture.Width / Sprite.columns ;
            int Height = Sprite.Texture.Height / Sprite.rows;
            int rows = Sprite.rows;
            int columns = Sprite.columns;
            int frame = Sprite.Frame;
            int rowheight = Height / rows;
            int columnwidth = Width / columns;

            int row = frame / columns;
            int column = frame % columns;

            Rectangle sourceRect = new Rectangle(columnwidth * column, rowheight * row, Width, Height);
            Rectangle DestinationRect = new Rectangle((int)location.X, (int)location.Y, Width, Height);

            Rectangle destinationRectangle = new Rectangle((int) location.X, (int) location.Y, Width, Height);

            SYSTEM.SpriteBatch.Draw(Sprite.Texture, destinationRectangle, sourceRect, Color.White);
        }

        public override void Instantiate(AncSystem sys)
        {
            SYSTEM = sys;
            Sprite = new AncAnimatedSprite(this, 1 , 4);
            Sprite.FileLocation = "peterwalking";
            AnchorAniSprite = Sprite;
        }
    }
}