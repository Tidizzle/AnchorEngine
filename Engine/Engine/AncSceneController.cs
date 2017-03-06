using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Engine
{
    public class AncSceneController : IDisposable
    {
        internal AncSystem System;
        public  Dictionary<string, AncScene> SceneList = new Dictionary<string, AncScene>();
        public AncScene CurrentScene;

        public void Add(AncScene scene)
        {
            SceneList.Add(scene.Name, scene);
        }

        public void Instantiate()
        {
            CurrentScene = SceneList.FirstOrDefault().Value;

            foreach (var scene in SceneList.Values)
            {
                scene.GraphicsDevice = System.GraphicsDevice;
                scene.Instantiate(System);
            }


        }

        public void LoadContent()
        {
            foreach (var scene in SceneList.Values)
            {
                scene.LoadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            CurrentScene.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            System.GraphicsDevice.Clear(Color.Green);
            CurrentScene.Draw(gameTime);
        }

        public void Dispose()
        {
            CurrentScene.Dispose();
        }

        public void DisposeAll()
        {
            foreach (var scene in SceneList.Values)
            {
                scene.Dispose();
            }
        }

        #region Scene Modification

        internal AncScene Curr;

        public void SwitchScene(string sceneName)
        {
            Curr = new DefaultScene("SafeDefault");
            if (SceneList.ContainsKey(sceneName))
            {
                Curr = SceneList[sceneName];
            }

            Console.WriteLine(Curr.Name);
            CurrentScene = Curr;
        }

        #endregion
    }
}