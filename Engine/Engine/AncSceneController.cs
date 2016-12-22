using System;
using System.Collections.Generic;
using System.Xml.Serialization.Configuration;
using Microsoft.Xna.Framework;

namespace Engine
{
    public class AncSceneController : IDisposable
    {
        private AncSystem SYSTEM;
        private Dictionary<string, AncScene> sceneList;
        private AncScene currentScene;

        public AncSceneController(AncSystem sys)
        {
            SYSTEM = sys;
            sceneList = new Dictionary<string, AncScene>();
        }

        public void Add(AncScene scene)
        {
            sceneList.Add(scene.Name, scene);
        }

        public void Instantiate()
        {
            foreach (var scene in sceneList)
            {
                scene.Instantiate(SYSTEM);
            }
        }

        public void LoadContent()
        {
            foreach (var scene in sceneList)
            {
                scene.LoadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }

        public void Dispose()
        {
            currentScene.Dispose();
        }
    }
}