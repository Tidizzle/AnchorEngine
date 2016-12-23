using OpenTK.Audio.OpenAL;
using Microsoft.Xna.Framework;

namespace Engine
{
    public abstract class Anchor
    {
        public string Name;
        public AncType Value;
        public AncSystem SYSTEM;

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public abstract void Instantiate(AncSystem sys);
        public virtual void AddValue(AncType value)
        {
            Value = value;
        }



    }
}