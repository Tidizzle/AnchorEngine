using System;
using Microsoft.Xna.Framework;

namespace Engine
{
    public abstract class Anchor : IDisposable
    {
        public string Name;
        public AncSystem SystemRef;
        public AncSprite AnchorSprite;
        public AncAnimatedSprite AnchorAniSprite;
        public AncScene Parent;
        public Vector2 Location;
        public Camera GlobalCamera;
        public string Focus;
        public int GlobalWidth;
        public int GlobalHeight;
	    public Vector2 Scale;
                                    public bool canMove;


        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public abstract void Instantiate(AncSystem sys, AncScene scene);

        public virtual void Dispose()
        {
            AnchorSprite?.Dispose();
        }

        public virtual Vector2 GetBottomLeft()
        {
            return new Vector2(Location.X, Location.Y + GlobalHeight);
        }

        public virtual Vector2 GetBottomRight()
        {
            return new Vector2(Location.X + GlobalWidth, Location.Y + GlobalHeight);
        }

    }
}