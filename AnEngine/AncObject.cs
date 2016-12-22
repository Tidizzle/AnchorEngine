using AnEngine.Properties;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AnEngine
{
    public class AncObject
    {
        public AncScene parentScene;
        public AncType Value;
        public Vector2 Location;
        public bool Static;

        public string objectName;

        #region Constructors

        public AncObject(AncScene scene, AncSprite sprite, bool isstatic)
        {
            parentScene = scene;
            Value = sprite;
            Static = isstatic;
        }

        public AncObject(AncScene scene, AncAnimatedSprite aniSprite)
        {
            parentScene = scene;
            Value = aniSprite;
        }

        public AncObject(AncScene scene, AncSound sound)
        {
            parentScene = scene;
            Value = sound;
        }

        public AncObject(AncScene scene, AncBackground background)
        {
            parentScene = scene;
            Value = background;
        }

        #endregion Constructors

        public void Load()
        {
            Value.Load();
        }

        public void Draw(SpriteBatch batch)
        {
            Value.Draw(batch);
        }

        public void Update(GameTime gameTime)
        {
            Value.Update(gameTime);
        }

        public void CheckMove()
        {
        }
    }
}