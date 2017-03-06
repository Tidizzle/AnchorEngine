using System.Collections.Generic;
using Engine;
using Microsoft.Xna.Framework;

namespace Test
{
    public class Scene1 : AncScene
    {

        public Scene1(string name) : base(name)
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
            System = sys;
            ObjectList = new Dictionary<string, Anchor>();

            //var peter = new PeterAni("Peter");
            //peter.Instantiate(sys, this);

	        var adam = new Adam("AdamSheetCorners");
	        adam.Instantiate(sys, this);


            var palm = new Palm("Palm");
            palm.Instantiate(sys, this);

	        var bg = new IslandTwentySeventeen("Island", adam, palm);
	        bg.Instantiate(sys, this);

	        var camera = new Camera(sys.GraphicsDevice, "Camera", adam);
           camera.Instantiate(sys, this);



	        AddObj(bg);
	        AddObj(palm);
	        AddObj(adam);
	        //addObj(peter);
	        AddObj(camera);

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