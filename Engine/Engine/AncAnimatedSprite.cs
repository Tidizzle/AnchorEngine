using System;
using Microsoft.Xna.Framework.Graphics;
using OpenTK;

namespace Engine
{
    public class AncAnimatedSprite : IDisposable
    {
        public AncAnimatedSprite(Anchor Parent, int rows, int columns)
        {
            this.Parent = Parent;

            this.rows = rows;
            this.columns = columns;
            this.Frames = this.rows * this.columns;
            this.Frame = 0;
        }

        public Anchor Parent;
        public Texture2D Texture;
        public string FileLocation;
        public Vector2 Location;
        public int rows;
        public int columns;
        public int Frames;
        public int Frame;

        public void Dispose()
        {
        }
    }
}