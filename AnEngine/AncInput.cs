using Microsoft.Xna.Framework.Input;
using OpenTK.Graphics.ES20;

namespace AnEngine
{
    public class AncInput
    {
        public static KeyboardState KeyboardState;
        public static MouseState MouseState;
        public static KeyboardState PreviousKeyboardState;
        public static MouseState PreviousMouseState;

        public void Update()
        {
            PreviousKeyboardState = KeyboardState;
            PreviousMouseState = MouseState;

            KeyboardState = Keyboard.GetState();
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
            return KeyboardState.IsKeyDown(k);
        }
    }
}