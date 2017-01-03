using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    public class Peter : Anchor
    {
        private AncSprite Sprite;
        private readonly Vector2 Scale = new Vector2(10f);
        private Vector2 location;
        private Vector2 Origin;
        private SpriteEffects effect;

        public Peter(string name)
        {
            Name = name;
        }

        public override void LoadContent()
        {
            Sprite.Texture = SYSTEM.Content.Load<Texture2D>(Sprite.fileLocation);
            AnchorSprite = Sprite;

            location.X = SYSTEM.GraphicsDevice.Viewport.Width / 2f;
            location.Y = SYSTEM.GraphicsDevice.Viewport.Height / 2f;
            Origin.X = Sprite.Texture.Width / 2f;
            Origin.Y = Sprite.Texture.Height / 2f;

        }

        public override void Update(GameTime gameTime)
        {
            AncInput.Update();

            if (AncInput.KeyHeld(Keys.A) || AncInput.KeyDown(Keys.A))
            {
                effect = SpriteEffects.FlipHorizontally;

                location += new Vector2(-5,0);
            }

            if (AncInput.KeyDown(Keys.D) || AncInput.KeyHeld(Keys.D))
            {
                effect = SpriteEffects.None;

                location += new Vector2(5, 0);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            int x = SYSTEM.GraphicsDevice.Viewport.Width / 2 + Sprite.Texture.Width / 2;
            int y = SYSTEM.GraphicsDevice.Viewport.Height / 2 + Sprite.Texture.Height / 2;
            SYSTEM.SpriteBatch.Draw(Sprite.Texture, location, color: Color.White, scale: Scale, origin: Origin, effects: effect);
        }


        public override void Instantiate(AncSystem sys, AncScene scene)
        {
            SYSTEM = sys;
            Sprite = new AncSprite(this);
            Sprite.fileLocation = "peter";
            AnchorSprite = Sprite;

        }
    }
}