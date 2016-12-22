using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

namespace AnEngine
{
    public abstract class AncType
    {
        public virtual void Load()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch batch)
        {
        }
    }
}