using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Engine
{
    public class AncSystem : Game
    {
        public GraphicsDeviceManager Graphics;
        public AncSceneController Controller;
        public SpriteBatch SpriteBatch;
        public SamplerState state = SamplerState.PointClamp;

        public AncSystem(int width, int height, bool fullscreen, bool multisampling)
        {
            Graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = width,
                PreferredBackBufferHeight = height,
                IsFullScreen = fullscreen,
                PreferMultiSampling = multisampling
            };

            Controller = new AncSceneController();
        }

        protected override void LoadContent()
        {

            Content.RootDirectory = "Content/";
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Controller.Instantiate();
            Controller.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Controller.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin(samplerState: state);
            Controller.Draw(gameTime);
            SpriteBatch.End();
        }

        protected override void Dispose(bool disposing)
        {
            Controller.Dispose();
        }
    }

}