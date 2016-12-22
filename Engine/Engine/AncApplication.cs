using System;

namespace Engine
{
    public class AncApplication : IDisposable
    {
        private AncSystem SYSTEM;

        public AncApplication(int width, int height, bool fullscreen, bool multisampling)
        {
            SYSTEM = new AncSystem(width, height, fullscreen, multisampling);
        }

        public void Start(params AncScene[] scenes)
        {
            if (scenes.Length > 0)
            {
                foreach (var scene in scenes)
                {
                    SYSTEM.Controller.Add(scene);
                }
            }
            SYSTEM.Run();
        }

        public void Dispose()
        {
        }
    }
}