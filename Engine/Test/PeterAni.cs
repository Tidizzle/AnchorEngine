using System;
using System.ComponentModel;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    public class PeterAni : Anchor
    {
        private AncAnimatedSprite Sprite;
        //private Vector2 origin;
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

	        GlobalWidth = Sprite.Texture.Width / Sprite.columns;
	        GlobalHeight = Sprite.Texture.Height;
	        Scale = new Vector2(10f);

	        Location.X = Parent.GraphicsDevice.Viewport.Width / 2 - (int) (GlobalWidth / 2f * Scale.X);
	        Location.Y = SYSTEM.GraphicsDevice.Viewport.Height / 2 -  (int) (GlobalHeight / 2f * Scale.Y);
        }

        public override void Update(GameTime gameTime)
        {
	        var deltatime = gameTime.ElapsedGameTime.TotalSeconds;

            AncInput.Update();

            if (AncInput.KeyHeld(Keys.A))
            {
                starting = 4;
                ending = 7;
                if (Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                Location.X -= (float) ( 500 * deltatime);
                //onsole.WriteLine("Walk west");
            }
            else if (AncInput.KeyHeld(Keys.D))
            {
                starting = 0;
                ending = 3;
                if ( Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                Location.X += (float)(500 * deltatime);
                //Console.WriteLine("Walk east");
            }
            else if (AncInput.KeyHeld(Keys.W))
            {
                starting = 8;
                ending = 10;
                if (Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                Location.Y -= (float)( 500 * deltatime);
                //Console.WriteLine("Walk north");
            }
            else if (AncInput.KeyHeld(Keys.S))
            {
                starting = 11;
                ending = 14;
                if (Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                Location.Y += (float) (500  * deltatime);
                //onsole.WriteLine("Walk south");
            }
            else if (AncInput.KeyHeld(Keys.LeftControl))
            {
                starting = 16;
                ending = 16;
                if (Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                //Console.WriteLine("Crouch");
            }
            else if (AncInput.KeyUp(Keys.LeftControl))
            {
                starting = 15;
                ending = 17;
                if (Sprite.Frame < starting || Sprite.Frame > ending)
                {
                    Sprite.Frame = starting;
                }
                //Console.WriteLine("Crouch");
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
	        destrect.X = (int) Location.X;
	        destrect.Y = (int) Location.Y;

            Rectangle sourcerect = new Rectangle();
            sourcerect.Width = Sprite.Texture.Width / Sprite.columns;
            sourcerect.Height = Sprite.Texture.Height / Sprite.rows;
            sourcerect.X = Sprite.Frame * columnwidth;
            sourcerect.Y = 0;

            SYSTEM.SpriteBatch.Draw(Sprite.Texture, destrect, sourcerect, Color.White);
        }

        public override void Instantiate(AncSystem sys, AncScene scene)
        {
            SYSTEM = sys;
            Sprite = new AncAnimatedSprite(this, 1, 18);
            Sprite.FileLocation = "peterspritesheet";
            AnchorAniSprite = Sprite;
            Parent = scene;


        }
    }
}

