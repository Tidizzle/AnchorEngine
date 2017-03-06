using System.Dynamic;
using Microsoft.Xna.Framework;

namespace Engine
{
    public class ObjectData
    {
        public Rectangle ObjectBounds;
        public Vector2 Position;
        public Vector2 Scale;

        public ObjectData(Vector2 position, int width, int height, Vector2 scale)
        {
            ObjectBounds = new Rectangle((int) position.X, (int) position.Y, width * (int) scale.X,
                height * (int) scale.Y);
            Position = new Vector2(position.X, position.Y);
            this.Scale = scale;
        }

        public bool ContainsVector(Vector2 position, int width)
        {
            var returner = ObjectBounds.Contains(position) ||
                           ObjectBounds.Contains(new Vector2(position.X + width, position.Y));

            return returner;

        }


    }
}
