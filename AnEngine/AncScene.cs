using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnEngine
{
    public abstract class AncScene : IDisposable
    {
        public string sceneName;
        public Dictionary<string, AncObject> objectList;
        public AncSystem system;

        protected AncScene(string name)
        {
            sceneName = name;
            objectList = new Dictionary<string, AncObject>();
        }

        public abstract void Start(); //Initailize All Objects here

        public abstract void Load();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch batch);

        public abstract void Dispose();
    }
}