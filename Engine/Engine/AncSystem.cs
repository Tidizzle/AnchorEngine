using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Engine
{
    public class AncSystem : Game
    {
        private GraphicsDeviceManager Graphics;
        public AncSceneController Controller;

        public AncSystem(int width, int height, bool fullscreen, bool multisampling)
        {
            Graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = width,
                PreferredBackBufferHeight = height,
                IsFullScreen = fullscreen,
                PreferMultiSampling = multisampling
            };

            Controller = new AncSceneController(this);
        }

        protected override void LoadContent()
        {
            Controller.Instantiate();
            Controller.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Controller.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Controller.Draw(gameTime);
        }

        protected override void Dispose(bool disposing)
        {
            Controller.Dispose();
        }
    }

}