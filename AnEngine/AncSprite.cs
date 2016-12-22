using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.Cryptography.X509Certificates;

namespace AnEngine
{
    public class AncSprite : AncType
    {
        public Texture2D texture;
        public string fileLocation;
        public AncSystem SYSTEM;
        public Vector2 Location;
        public bool Static;
        public Vector2 scale;

        public AncSprite(AncSystem sys)
        {
            SYSTEM = sys;
        }

        public override void Load()
        {
            Console.WriteLine(texture);
            if (SYSTEM == null)
            {
                Console.WriteLine("tis fuken broken bitch");
            }
            Console.WriteLine(fileLocation);

            texture = SYSTEM.Content.Load<Texture2D>(fileLocation);
            Location = new Vector2(0, 0);
            scale = new Vector2(4);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Static)
            {
                Vector2 T = Vector2.Zero;

                if (AncInput.KeyHeld(Keys.A))
                {
                    T += new Vector2(-1, 0);
                }
                if (AncInput.KeyHeld(Keys.S))
                {
                    T += new Vector2(0, 1);
                }
                if (AncInput.KeyHeld(Keys.D))
                {
                    T += new Vector2(1, 0);
                }
                if (AncInput.KeyHeld(Keys.W))
                {
                    T += new Vector2(0, -1);
                }
                if (T != Vector2.Zero)
                    Location += Vector2.Normalize(T) * 500 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            //var batch = SYSTEM.spriteBatch;
            batch.Draw(texture, Location, color: Color.White, scale: scale);
        }
    }
}