using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AnEngine
{
    public class AncApplication : Game, IDisposable
    {
        AncSystem system;

        public AncApplication(int height = 800, int width = 1000, bool fullscreen = false, bool multisampling = false )
        {
            system = new AncSystem(height, width, fullscreen, multisampling);
        }

        public void Start(params AncScene[] scenes)
        {
            if (scenes.Length > 0)
            {
                foreach (var scene in scenes)
                {
                    system.SController.Add(scene);
                }
            }
            else
            {
                var scene = new DefaultScene("default");
                system.SController.Add(scene);
            }

            system.Run();
        }

        public new void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
