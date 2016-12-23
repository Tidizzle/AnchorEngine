using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization.Configuration;
using Microsoft.Xna.Framework;

namespace Engine
{
    public class AncSceneController : IDisposable
    {
        internal AncSystem SYSTEM;
        private Dictionary<string, AncScene> sceneList = new Dictionary<string, AncScene>();
        private AncScene currentScene;

        public void Add(AncScene scene)
        {
            sceneList.Add(scene.Name, scene);
        }

        public void Instantiate()
        {
            foreach (var scene in sceneList.Values)
            {
                scene.Instantiate(SYSTEM);
            }

            currentScene = sceneList.FirstOrDefault().Value;
        }

        public void LoadContent()
        {
            foreach (var scene in sceneList.Values)
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
            SYSTEM.GraphicsDevice.Clear(Color.CornflowerBlue);
            currentScene.Draw(gameTime);
        }

        public void Dispose()
        {
            //currentScene.Dispose();
        }
    }
}