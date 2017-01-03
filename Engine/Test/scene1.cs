using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;

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
            SYSTEM = sys;
            objectList = new Dictionary<string, Anchor>();

            //var peter = new PeterAni("Peter");
            //peter.Instantiate(sys, this);

	        var adam = new Adam("Adam");
	        adam.Instantiate(sys, this);

	        var bg = new TiledIsland("Island", adam);
	        bg.Instantiate(sys, this);

	        var camera = new Engine.Camera(sys.GraphicsDevice, "Camera", adam);
           camera.Instantiate(sys, this);

	        var Palm = new Palm("Palm");
	        Palm.Instantiate(sys, this);

	        addObj(bg);
	        addObj(Palm);
	        addObj(adam);
	        //addObj(peter);
	        addObj(camera);

	        //var peter = new Peter("Peter");
            //peter.Instantiate(sys);
            //addObj(peter);

            //var sticky = new sticky("Sticky");
            //sticky.Instantiate(sys);
            //objectList.Add(sticky.Name, sticky);
	        /*
            var bg = new Grassbg("Grass");
            bg.Instantiate(sys, this);
            addObj(bg);


	        var beach = new Beach("Beach");
	        beach.Instantiate(sys, this);
			addObj(beach);
			*/
        }
    }
}