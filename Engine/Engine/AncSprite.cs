using System;
using Microsoft.Xna.Framework.Graphics;
using OpenTK;

namespace Engine
 {
     public class AncSprite : IDisposable
     {
         public AncSprite(Anchor parent)
         {
             this.parent = parent;
         }

         public Anchor parent;
         public Texture2D Texture;
         public string fileLocation = "";
         public Vector2 currentLoc;

         public void Dispose()
         {
             Texture?.Dispose();
         }
     }
 }