using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Engine
{
    public class DefaultScene : AncScene
    {

        public DefaultScene(string name) : base(name)
        {
            Name = name;
        }

        public override void LoadContent()
        {
            foreach (var obj in ObjectList.Values)
            {
                obj.LoadContent();
            }

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var obj in ObjectList.Values)
            {
                obj.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var obj in ObjectList.Values)
            {
                obj.Draw(gameTime);
            }
        }

        public override void Instantiate(AncSystem sys)
        {
            ObjectList = new Dictionary<string, Anchor>();
            var bg = new RedBackground("Red");
            bg.Instantiate(sys, this);
            ObjectList.Add(bg.Name, bg);
        }
    }
}