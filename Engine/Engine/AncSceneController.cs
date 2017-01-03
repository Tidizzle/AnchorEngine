using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class AncSceneController : IDisposable
    {
        internal AncSystem SYSTEM;
        public  Dictionary<string, AncScene> sceneList = new Dictionary<string, AncScene>();
        public AncScene currentScene;

        public void Add(AncScene scene)
        {
            sceneList.Add(scene.Name, scene);
        }

        public void Instantiate()
        {
            currentScene = sceneList.FirstOrDefault().Value;

            foreach (var scene in sceneList.Values)
            {
                scene.GraphicsDevice = SYSTEM.GraphicsDevice;
                scene.Instantiate(SYSTEM);
            }


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
            SYSTEM.GraphicsDevice.Clear(Color.Green);
            currentScene.Draw(gameTime);
        }

        public void Dispose()
        {
            currentScene.Dispose();
        }

        public void DisposeAll()
        {
            foreach (var scene in sceneList.Values)
            {
                scene.Dispose();
            }
        }

        #region Scene Modification

        internal AncScene curr;

        public void switchScene(String SceneName)
        {
            curr = new DefaultScene("SafeDefault");
            if (sceneList.ContainsKey(SceneName))
            {
                this.curr = sceneList[SceneName];
            }

            Console.WriteLine(curr.Name);
            currentScene = curr;
        }

        #endregion
    }
}