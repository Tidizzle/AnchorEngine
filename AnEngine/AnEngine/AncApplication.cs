using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace AnEngine
{
    public class AncApplication
    {
        private AncSystem SYSTEM;

        public AncApplication(int height, int width, bool fullscreen, bool multisampling)
        {
             SYSTEM = new AncSystem(height, width, fullscreen, multisampling);
        }

        public void Start(params AncScene[] scenes )
        {
            if (scenes.Length > 0)
            {
                foreach (AncScene scene in scenes)
                {
                    SYSTEM.Controller.Add(scene, scene.sceneName);
                }
            }
            else
            {
                //create default scene!!!
            }
        }
    }
}
