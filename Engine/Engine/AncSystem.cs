using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine;

namespace Engine
{
    public class AncSystem : Game
    {
        public GraphicsDeviceManager Graphics;
        public AncSceneController Controller;
        public SpriteBatch SpriteBatch;
        public SamplerState State = SamplerState.PointClamp;
        public Matrix TransformMatrix;

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

		    var camera = Controller.CurrentScene.ObjectList["Camera"].GlobalCamera;

	        var viewMatrix = camera.GetViewMatrix();

            SpriteBatch.Begin(samplerState: State, transformMatrix: viewMatrix, sortMode: SpriteSortMode.FrontToBack);
            Controller.Draw(gameTime);
            SpriteBatch.End();
        }

        protected override void Dispose(bool disposing)
        {
            Controller.Dispose();
        }
    }

}