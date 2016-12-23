using Microsoft.Xna.Framework.Graphics;
using OpenTK;

namespace Engine
 {
     public class AncSprite : AncType
     {
         public AncSprite(Anchor parent)
         {
             this.parent = parent;
         }

         public Anchor parent;
         public Texture2D Texture;
         public string fileLocation = "";
         public Vector2 currentLoc;
     }
 }