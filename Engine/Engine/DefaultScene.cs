using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Test;

namespace Engine
{
    public class DefaultScene : AncScene
    {

        public DefaultScene(string Name) : base(Name)
        {
            base.Name = Name;
        }

        public override void LoadContent()
        {
            foreach (var obj in objectList.Values)
            {
                obj.LoadContent();
            }

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var obj in objectList.Values)
            {
                obj.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var obj in objectList.Values)
            {
                obj.Draw(gameTime);
            }
        }

        public override void Instantiate(AncSystem sys)
        {
            objectList = new Dictionary<string, Anchor>();
            var bg = new RedBackground("Red");
            bg.Instantiate(sys);
            objectList.Add(bg.Name, bg);
        }
    }
}