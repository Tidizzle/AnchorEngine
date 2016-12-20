using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace AnEngine
{
    public class AncSceneController
    {
        private Dictionary<string, AncScene> sceneList;
        private AncSystem SYSTEM;
        private AncScene currentScene;

        public AncSceneController(AncSystem system)
        {
            SYSTEM = system;
            sceneList = new Dictionary<string, AncScene>();
        }

        public void Add(AncScene scene, string sceneName)
        {
            sceneList?.Add(sceneName, scene);
        }

        public void Start()
        {
            currentScene = sceneList.First().Value;
            currentScene.Start();
        }

    }
}
