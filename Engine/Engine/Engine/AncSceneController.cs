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

        public void switchScene(String SceneName, SpriteBatch batch)
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