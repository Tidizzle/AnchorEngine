using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace AnEngine
{
    public abstract class AncScene : IDisposable
    {
        public string sceneName;
        public Dictionary<string, AncObject> objectList;

        protected AncScene(string name)
        {
            sceneName = name;
        }

        public abstract void Start();
        public abstract void Load();
        public abstract void Update();
        public abstract void Draw();

        public abstract void Dispose();
    }
}
