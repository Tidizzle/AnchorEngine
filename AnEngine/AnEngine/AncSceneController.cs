using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AnEngine
{
    public class AncSceneController
    {
        public Dictionary<string, AncScene> Scenelist;
        public AncScene currentScene;

        public AncSceneController()
        {
            Scenelist = new Dictionary<string, AncScene>();
            currentScene = Scenelist.First().Value;
        }


        public void Add(AncScene scene)
        {
            Scenelist.Add(scene.SceneName, scene);
        }

        public void Start(GraphicsDevice graphicsDevice)
        {
            SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
            load(currentScene, spriteBatch);
        }

        public void load(AncScene scene, SpriteBatch spriteBatch)
        {
            for(int i = 0; i < scene.ObjList.Count; i++)
            {
                for(int j = 0; j < scene.ObjList[i].SpriteList.Count; j++)
                {
                    int x = (int)scene.ObjList[i].SpriteList[j].location.X;
                    int y = (int)scene.ObjList[i].SpriteList[j].location.Y;
                    int width = scene.ObjList[i].SpriteList[j].texture.Width;
                    int height = scene.ObjList[i].SpriteList[j].texture.Height;

                    spriteBatch.Begin();
                    spriteBatch.Draw(scene.ObjList[i].SpriteList[j].texture, new Rectangle(x,y,width,height), Color.White );
                    spriteBatch.End();
                }
            }
        }


        public void Update(AncScene currentScene)
        {
            foreach(var obj in currentScene.ObjList)
            {
                
            }
        }




    }
}
