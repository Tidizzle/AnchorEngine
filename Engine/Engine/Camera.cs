using System;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Camera : Anchor
    {
        public Viewport _Viewport;

 		 private float rotation;
		 private float zoom;
		 //private Vector2 location;
		 private Vector2 origin;
		 private Anchor RefToFocus;


		 public Camera(GraphicsDevice graphicsDevice, string name, Anchor Ref)
		 {
			 _Viewport = graphicsDevice.Viewport;
			 Name = name;
			 RefToFocus = Ref;


        }

        public Matrix GetViewMatrix()
        {
	        return
		        Matrix.CreateTranslation(-Location.X, -Location.Y, 0) *
		        Matrix.CreateRotationZ(rotation) *
		        Matrix.CreateScale(zoom, zoom, 1)  *
	       		Matrix.CreateTranslation( (int) (Parent.GraphicsDevice.Viewport.Width / 2f), (int) (Parent.GraphicsDevice.Viewport.Height / 2f), 0);

        }

	    public override void LoadContent()
	    {
		    Location.X = RefToFocus.Location.X + (int) (RefToFocus.GlobalWidth / 2f * RefToFocus.Scale.X);
		    Location.Y = RefToFocus.Location.Y + (int) (RefToFocus.GlobalHeight / 2f * RefToFocus.Scale.Y);

	    }


	    public override void Update(GameTime gameTime)
        {

            var deltatime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (AncInput.KeyHeld(Keys.Q))
                rotation -= 1 * deltatime;

            if (AncInput.KeyHeld(Keys.E))
                rotation += 1 * deltatime;

            if (AncInput.KeyDown(Keys.Space))
                rotation = 0;

            if (AncInput.KeyHeld(Keys.R))
                zoom += .1f;

            if (AncInput.KeyHeld(Keys.F))
                zoom -= .1f;

	        if (zoom <= .6f)
	        {
		        zoom = 0.6f;
	        }
	        else if (zoom >= 1.1f)
	        {
		        zoom = 1.1f;
	        }

	        if (AncInput.KeyHeld(Keys.Escape))
	        {
		        SYSTEM.Exit();
	        }

            GlobalCamera = this;

	        Location.X = RefToFocus.Location.X + (int) (RefToFocus.GlobalWidth / 2f * RefToFocus.Scale.X);
	        Location.Y = RefToFocus.Location.Y + (int) (RefToFocus.GlobalHeight / 2f * RefToFocus.Scale.Y);
	        Console.WriteLine(zoom);

        }

        public override void Draw(GameTime gameTime)
        {

        }

        public override void Instantiate(AncSystem sys, AncScene scene)
        {
            Parent = scene;
            SYSTEM = sys;
            GlobalCamera = this;

            rotation = 0;
            zoom = 1;

        }
    }
}