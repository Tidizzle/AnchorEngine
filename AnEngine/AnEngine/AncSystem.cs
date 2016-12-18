using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace AnEngine
{
    public class AncSystem : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public AncSceneController SController;

        public AncSystem(int height, int width, bool fullscreen, bool multisampling)
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.IsFullScreen = fullscreen;
            graphics.PreferMultiSampling = multisampling;
            graphics.ApplyChanges();

            SController = new AncSceneController();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();

            
        }



    }
}
