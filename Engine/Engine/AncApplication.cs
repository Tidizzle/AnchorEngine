using System;

namespace Engine
{
    public class AncApplication : IDisposable
    {
        private readonly AncSystem _system;

        public AncApplication(int width, int height, bool fullscreen, bool multisampling)
        {
            _system = new AncSystem(width, height, fullscreen, multisampling);
        }

        public void Start(params AncScene[] scenes)
        {
            _system.Controller.System = _system;

            if (scenes.Length > 0)
            {
                foreach (var scene in scenes)
                {
                    _system.Controller.Add(scene);
                }
            }
            _system.Run();
        }

        public void Dispose()
        {
            _system.Dispose();
        }
    }
}