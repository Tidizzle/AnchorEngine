using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AnEngine
{
    public class AncAnimatedSprite : AncType
    {
        private int Rows, Columns, CurrentFrame, TotalFrames;
        private string fileLoc;
        private Texture2D Texture;
        private Vector2 location;
        private AncSystem SYSTEM;
        private AncScene SCENE;

        public AncAnimatedSprite(int rows, int columns, string fileloc, AncSystem sys, AncScene scene, Vector2 location)
        {
            Rows = rows;
            Columns = columns;
            fileLoc = fileloc;
            SYSTEM = sys;
            Texture = SYSTEM.Content.Load<Texture2D>(fileloc);
            TotalFrames = Rows * columns;
            this.location = location;
        }

        public override void Load()
        {
        }

        public override void Update(GameTime gameTime)
        {
            CurrentFrame++;
            if (CurrentFrame > TotalFrames)
                CurrentFrame = 0;
        }

        public void Run()
        {
            int rowheight = Texture.Height / Rows;
            int columnwidth = Texture.Width / Columns;
            int numframes = Rows * Columns;

            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            Rectangle destinationRect = new Rectangle((int)location.X, (int)location.Y, Texture.Width, Texture.Height);
            Rectangle sourceRect = new Rectangle((int)column * columnwidth, (int)row * rowheight, columnwidth, rowheight);

            //SCENE.spriteBatch.Draw(Texture, destinationRect, sourceRect, Color.White);
        }
    }
}