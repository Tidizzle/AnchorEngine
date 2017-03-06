using System;
using Microsoft.Xna.Framework.Graphics;
using OpenTK;

namespace Engine
{
    public class AncAnimatedSprite : IDisposable
    {
        public AncAnimatedSprite(Anchor parent, int rows, int columns)
        {
            Parent = parent;

            Rows = rows;
            Columns = columns;
            Frames = this.Rows * this.Columns;
            Frame = 0;
        }

        public Anchor Parent;
        public Texture2D Texture;
        public string FileLocation;
        public Vector2 Location;
        public int Rows;
        public int Columns;
        public int Frames;
        public int Frame;

        public void Dispose()
        {
        }
    }
}