using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public abstract class AncScene : IDisposable
    {
        public AncSystem SYSTEM;
        public Dictionary<string, Anchor> objectList;
        public string Name;
        public GraphicsDevice GraphicsDevice { get; internal set; }

        protected AncScene(string Name)
        {
            this.Name = Name;
        }

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public abstract void Instantiate(AncSystem sys);

        public virtual void addObj(Anchor anc)
        {
            objectList.Add(anc.Name, anc);
        }

        public virtual void  Dispose()
        {
            foreach (var obj in objectList.Values)
            {
                obj.Dispose();
            }
        }
    }
}