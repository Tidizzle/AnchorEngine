using System;
using Microsoft.Xna.Framework;

namespace Engine
{
    public abstract class Anchor : IDisposable
    {
        public string Name;
        public AncSystem SYSTEM;
        public AncSprite AnchorSprite;
        public AncAnimatedSprite AnchorAniSprite;

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public abstract void Instantiate(AncSystem sys);

        public virtual void Dispose()
        {
            AnchorSprite?.Dispose();
        }
    }
}