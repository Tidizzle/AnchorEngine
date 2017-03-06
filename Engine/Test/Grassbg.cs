using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test
{
    public class Grassbg  : Anchor
    {
        private AncSprite _sprite;

        public Grassbg(string name)
        {
            Name = name;
        }

        public override void LoadContent()
        {
            _sprite.Texture = SystemRef.Content.Load<Texture2D>(_sprite.FileLocation);
            AnchorSprite = _sprite;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {

            const int x = 5000;
            const int y = 5000;
            var width = _sprite.Texture.Width;
            var height = _sprite.Texture.Height;
            var columns = x / width + 1;
            var rows = y / height + 1;
            var cells = rows * columns;
            var current = 0;

            for (var i = 0; i < cells; i++)
            {
                var row = current / columns;
                var column = current % columns;

                var vecx = width * column;
                var vecy = height * row;

                SystemRef.SpriteBatch.Draw(_sprite.Texture, new Vector2(vecx, vecy), Color.White);
                current++;
            }

        }


        public override void Instantiate(AncSystem sys, AncScene scene)
        {
            SystemRef = sys;
            _sprite = new AncSprite(this) {FileLocation = "grass"};
            AnchorSprite = _sprite;
        }
    }
}