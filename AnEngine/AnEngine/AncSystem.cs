using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace AnEngine
{
    public class AncSystem : Game
    {
        private GraphicsDeviceManager Graphics;
        public AncSceneController Controller;
        

        public AncSystem(int height, int width, bool fullscreen, bool multisampling)
        {
            Graphics.PreferredBackBufferHeight = height;
            Graphics.PreferredBackBufferWidth = width;
            Graphics.IsFullScreen = fullscreen;
            Graphics.PreferMultiSampling = multisampling;

            Controller = new AncSceneController(this);
        }

        public void Start()
        {

        }

        protected override void Initialize()
        {

        }

        protected override void LoadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

        }

        protected override void Draw(GameTime gameTime)
        {

        }

        protected override void UnloadContent()
        {

        }
    }
}
