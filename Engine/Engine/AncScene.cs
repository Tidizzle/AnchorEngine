using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Engine
{
    public abstract class AncScene
    {
        public AncSystem SYSTEM;
        public Dictionary<string, AncObject> objectList;

        public abstract void Load();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public abstract void Instantiate();

    }
}