using System;
using System.Collections.Generic;
using Engine;
using Microsoft.Xna.Framework;

namespace Test
{
    public class scene1 : AncScene
    {
        public scene1(string Name) : base(Name)
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
            var sticky = new sticky("Sticky");
            sticky.Instantiate(sys);
            objectList.Add(sticky.Name, sticky);
        }
    }
}