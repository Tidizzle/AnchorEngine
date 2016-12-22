using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnEngine
{
    public class AncSystem : Game
    {
        private GraphicsDeviceManager Graphics;
        public AncSceneController Controller;
        public SpriteBatch spriteBatch;
        public AncInput Input;
        public SamplerState state = SamplerState.PointClamp;

        public AncSystem(int height, int width, bool fullscreen, bool multisampling)
        {
            Graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = height,
                PreferredBackBufferWidth = width,
                IsFullScreen = fullscreen,
                PreferMultiSampling = multisampling
            };

            Controller = new AncSceneController(this);
        }

        protected override void LoadContent()
        {
            Input = new AncInput();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Controller.Load();
            Controller.Start();
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            Controller.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(samplerState: state);
            Controller.Draw(spriteBatch);
            spriteBatch.End();
        }

        protected override void UnloadContent()
        {
        }
    }
}