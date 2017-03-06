using Microsoft.Xna.Framework.Input;

namespace Engine
 {
     public static class AncInput
     {
         public static KeyboardState KeyboardState;
         public static KeyboardState PreviousKeyboardState;
         public static MouseState MouseState;
         public static MouseState PreviousMouseState;

         public static void Update()
         {
             PreviousKeyboardState = KeyboardState;
             KeyboardState = Keyboard.GetState();

             PreviousMouseState = MouseState;
             MouseState = Mouse.GetState();
         }

         public static bool KeyUp(Keys k)
         {
             return KeyboardState.IsKeyUp(k) && PreviousKeyboardState.IsKeyDown(k);
         }

         public static bool KeyDown(Keys k)
         {
             return KeyboardState.IsKeyDown(k) && PreviousKeyboardState.IsKeyUp(k);
         }

         public static bool KeyHeld(Keys k)
         {
             return KeyboardState.IsKeyDown(k) && PreviousKeyboardState.IsKeyDown(k);
         }

         public static bool MouseLeftDown()
         {
             return MouseState.LeftButton == ButtonState.Pressed && PreviousMouseState.LeftButton == ButtonState.Released;
         }

         public static bool MouseLeftHeld()
         {
             return MouseState.LeftButton == ButtonState.Pressed;
         }

         public static bool MouseLeftUp(Keys k)
         {
             return MouseState.LeftButton == ButtonState.Released && PreviousMouseState.LeftButton == ButtonState.Pressed;
         }

     }
 }