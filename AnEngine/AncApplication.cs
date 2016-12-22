using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AnEngine
{
    public class AncApplication
    {
        public AncSystem system;

        public AncApplication(int height, int width, bool fullscreen, bool multisampling)
        {
            var sys = new AncSystem(height, width, fullscreen, multisampling);
            system = sys;
        }

        public void Start(SpriteBatch spriteBatch, params AncScene[] scenes)
        {
            if (scenes.Length > 0)
            {
                foreach (AncScene scene in scenes)
                {
                    system.Controller.Add(scene, scene.sceneName);
                    scene.system = system;
                }
            }
            else
            {
                //create default scene!!!
            }

            system.Run();
        }
    }
}