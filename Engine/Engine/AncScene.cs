﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Engine
{
    public abstract class AncScene : IDisposable
    {
        public AncSystem SYSTEM;
        public Dictionary<string, Anchor> objectList;
        public string Name;

        protected AncScene(string Name)
        {
            this.Name = Name;
        }

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public abstract void Instantiate(AncSystem sys);

        public void Dispose()
        {

        }

    }
}