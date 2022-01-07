using Microsoft.Xna.Framework.Input;

namespace Portal2D.Implementations
{
    static class MouseReader
    {
        private static MouseState previousMouseState;

        public static MouseState GetState()
        {
            return previousMouseState;
        }

        public static bool leftClicked()
        {
            MouseState currentState = Mouse.GetState();

            bool isPressed = false;
            if (currentState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton != ButtonState.Pressed)
                isPressed = true;

            previousMouseState = currentState;
            return isPressed;
        }
    }
}
