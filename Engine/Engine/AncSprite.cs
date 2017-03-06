using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
 {
     public class AncSprite : IDisposable
     {
         public AncSprite(Anchor parent)
         {
             Parent = parent;
         }

         public Anchor Parent;
         public Texture2D Texture;
         public string FileLocation = "";
         public Vector2 CurrentLoc;

         public void Dispose()
         {
             Texture?.Dispose();
         }
     }
 }