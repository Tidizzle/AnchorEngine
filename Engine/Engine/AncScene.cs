using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public abstract class AncScene : IDisposable
    {
        public AncSystem System;
        public Dictionary<string, Anchor> ObjectList;
        public string Name;
        public GraphicsDevice GraphicsDevice { get; internal set; }

        protected AncScene(string name)
        {
            Name = name;
        }

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public abstract void Instantiate(AncSystem sys);

        public virtual void AddObj(Anchor anc)
        {
            ObjectList.Add(anc.Name, anc);
        }

        public virtual void  Dispose()
        {
            foreach (var obj in ObjectList.Values)
            {
                obj.Dispose();
            }
        }
    }
}