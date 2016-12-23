using System;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    public class sticky : Anchor
    {

        private AncSprite Sprite;
        private Vector2 scale = new Vector2(0);
        private Vector2 origin;
        private Vector2 location;

        public sticky(string name)
        {
            Name = name;
        }

        public override void LoadContent()
        {
            var loc = Sprite.fileLocation;
            Sprite.Texture = SYSTEM.Content.Load<Texture2D>(loc);

            origin.X = Sprite.Texture.Width / 2f;
            origin.Y = Sprite.Texture.Height / 2f;
            location.X = SYSTEM.GraphicsDevice.Viewport.Width / 2;
            location.Y = SYSTEM.GraphicsDevice.Viewport.Height / 2;
        }

        public override void Update(GameTime gameTime)
        {
            scale.X += 0.01f;
            scale.Y += 0.01f;


            location += new Vector2(-.1f,0);

            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
            {
                SYSTEM.Exit();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            int x = SYSTEM.GraphicsDevice.Viewport.Width / 2;
            int y = SYSTEM.GraphicsDevice.Viewport.Height / 2;
            SYSTEM.SpriteBatch.Draw(Sprite.Texture,location, color: Color.White, scale: scale, origin: origin);
        }

        public override void Instantiate(AncSystem sys)
        {
            SYSTEM = sys;
            Sprite = new AncSprite(this);
            Sprite.fileLocation = "stickdude2";


        }
    }
}