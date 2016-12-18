using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnEngine
{
    public class AncObject : Anchor
    {
        Anchor Script;
        AncScene Scene;

        public AncObject(AncScene scene, Anchor script)
        {
            Scene = scene;
            Script = script;

        }

       public void AddToScene()
        {
            Scene.ObjList.Add(this);

        }

        public void AddSprite(AncSprite sprite)
        {
            Script.SpriteList.Add(sprite);
        }

        public void update()
        {
            
        }

    }
}
