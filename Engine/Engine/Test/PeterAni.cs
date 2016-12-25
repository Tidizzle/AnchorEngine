using System;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using Engine;
using Microsoft.Win32;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Test
{
    public class PeterAni : Anchor
    {
        private AncAnimatedSprite Sprite;
        private readonly Vector2 Scale = new Vector2(10f);
        private Vector2 location;
        private Vector2 origin;
        private SpriteEffects effect;
        private int elapsedupdate;
        private readonly int frametime = 100;

        private int starting;
        private int ending;

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


            AncInput.Update();

            if (AncInput.KeyHeld(Keys.A))
            {
                starting = 4;
                ending = 7;
                if (Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                location.X -= 5;
                Console.WriteLine("Walk west");
            }
            else if (AncInput.KeyHeld(Keys.D))
            {
                starting = 0;
                ending = 3;
                if ( Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                location.X += 5;
                Console.WriteLine("Walk east");
            }
            else if (AncInput.KeyHeld(Keys.W))
            {
                starting = 8;
                ending = 10;
                if (Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                location.Y -= 5;
                Console.WriteLine("Walk north");
            }
            else if (AncInput.KeyHeld(Keys.S))
            {
                starting = 11;
                ending = 14;
                if (Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                location.Y += 5;
                Console.WriteLine("Walk south");
            }
            else if (AncInput.KeyHeld(Keys.LeftControl))
            {
                starting = 16;
                ending = 16;
                if (Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                Console.WriteLine("Crouch");
            }
            else if (AncInput.KeyUp(Keys.LeftControl))
            {
                starting = 15;
                ending = 17;
                if (Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                Console.WriteLine("Crouch");
            }
            else
            {
                starting = 11;
                ending = 11;
                Sprite.Frame = 11;
            }



            elapsedupdate += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedupdate > frametime)
            {
                elapsedupdate = 0;

                Sprite.Frame++;
                if (Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
            }


        }

        public override void Draw(GameTime gameTime)
        {

            int columnwidth = Sprite.Texture.Width / Sprite.columns;
            int rowheight = Sprite.Texture.Height / Sprite.rows;

            Rectangle destrect = new Rectangle();
            destrect.Width = columnwidth * 10;
            destrect.Height = rowheight * 10;
            destrect.X = (int) location.X - columnwidth / 2;
            destrect.Y = (int) location.Y - rowheight / 2;

            Rectangle sourcerect = new Rectangle();
            sourcerect.Width = Sprite.Texture.Width / Sprite.columns;
            sourcerect.Height = Sprite.Texture.Height / Sprite.rows;
            sourcerect.X = Sprite.Frame * columnwidth;
            sourcerect.Y = 0;

            SYSTEM.SpriteBatch.Draw(Sprite.Texture, destrect, sourcerect, Color.White);
        }

        public override void Instantiate(AncSystem sys)
        {
            SYSTEM = sys;
            Sprite = new AncAnimatedSprite(this, 1, 18);
            Sprite.FileLocation = "peterspritesheet";
            AnchorAniSprite = Sprite;
        }
    }
}

