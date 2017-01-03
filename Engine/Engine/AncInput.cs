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

         public static bool KeyUp(Keys K)
         {
             return KeyboardState.IsKeyUp(K) && PreviousKeyboardState.IsKeyDown(K);
         }

         public static bool KeyDown(Keys K)
         {
             return KeyboardState.IsKeyDown(K) && PreviousKeyboardState.IsKeyUp(K);
         }

         public static bool KeyHeld(Keys K)
         {
             return KeyboardState.IsKeyDown(K) && PreviousKeyboardState.IsKeyDown(K);
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