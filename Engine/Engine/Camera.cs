using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Camera : Anchor
    {
        public Viewport Viewport;

 		 private float _rotation;
		 private float _zoom;
		 private readonly Anchor _refToFocus;


		 public Camera(GraphicsDevice graphicsDevice, string name, Anchor Ref)
		 {
			 Viewport = graphicsDevice.Viewport;
			 Name = name;
			 _refToFocus = Ref;
		 }

        public Matrix GetViewMatrix()
        {
	        return
		        Matrix.CreateTranslation(-Location.X, -Location.Y, 0) *
		        Matrix.CreateRotationZ(_rotation) *
		        Matrix.CreateScale(_zoom, _zoom, 1)  *
	       		Matrix.CreateTranslation( (int) (Parent.GraphicsDevice.Viewport.Width / 2f), (int) (Parent.GraphicsDevice.Viewport.Height / 2f), 0);

        }

	    public override void LoadContent()
	    {
		    Location.X = _refToFocus.Location.X + (int) (_refToFocus.GlobalWidth / 2f * _refToFocus.Scale.X);
		    Location.Y = _refToFocus.Location.Y + (int) (_refToFocus.GlobalHeight / 2f * _refToFocus.Scale.Y);

	    }


	    public override void Update(GameTime gameTime)
        {

            var deltatime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (AncInput.KeyHeld(Keys.Q))
                _rotation -= 1 * deltatime;

            if (AncInput.KeyHeld(Keys.E))
                _rotation += 1 * deltatime;

            if (AncInput.KeyDown(Keys.Space))
                _rotation = 0;

            if (AncInput.KeyHeld(Keys.R))
                _zoom += .02f;

            if (AncInput.KeyHeld(Keys.F))
                _zoom -= .02f;

	        if (_zoom <= .1f)
	        {
		        _zoom = 0.1f;
	        }
	        else if (_zoom >= 3f)
	        {
		        _zoom = 3f;
	        }

	        if (AncInput.KeyHeld(Keys.Escape))
	        {
		        SystemRef.Exit();
	        }

            GlobalCamera = this;

	        Location.X = _refToFocus.Location.X + (int) (_refToFocus.GlobalWidth / 2f * _refToFocus.Scale.X);
	        Location.Y = _refToFocus.Location.Y + (int) (_refToFocus.GlobalHeight / 2f * _refToFocus.Scale.Y);
	        //Console.WriteLine(_zoom);

        }

        public override void Draw(GameTime gameTime)
        {

        }

        public override void Instantiate(AncSystem sys, AncScene scene)
        {
            Parent = scene;
            SystemRef = sys;
            GlobalCamera = this;

            _rotation = 0;
            _zoom = 1;

        }
    }
}