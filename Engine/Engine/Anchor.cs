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
        public AncScene Parent;
        public Vector2 Location;
        public Engine.Camera GlobalCamera;
        public string Focus;
        public int GlobalWidth;
        public int GlobalHeight;
	    public Vector2 Scale;


        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public abstract void Instantiate(AncSystem sys, AncScene scene);

        public virtual void Dispose()
        {
            AnchorSprite?.Dispose();
        }
    }
}