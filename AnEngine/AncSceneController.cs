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
    public class AncSceneController
    {
        private Dictionary<string, AncScene> sceneList;
        private AncSystem SYSTEM;
        private AncScene currentScene;
        private SpriteBatch spriteBatch;

        public AncSceneController(AncSystem system)
        {
            SYSTEM = system;
            sceneList = new Dictionary<string, AncScene>();
        }

        public void Add(AncScene scene, string sceneName)
        {
            sceneList?.Add(sceneName, scene);
        }

        public void Load()
        {
            foreach (var scene in sceneList.Values)
            {
                scene.Load();
                scene.system = SYSTEM;
            }
        }

        public void Start()
        {
            currentScene = sceneList.First().Value;
            currentScene.Start();
        }

        public void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            foreach (var obj in currentScene.objectList.Values)
            {
                obj.Draw(batch);
            }
        }
    }
}