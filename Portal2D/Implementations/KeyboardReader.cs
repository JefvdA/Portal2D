using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Portal2D.Interfaces;
using System.Diagnostics;

namespace Portal2D.Implementations
{
    class KeyboardReader : IInputReader
    {
        private KeyboardState previousState;

        public KeyboardReader()
        {
            previousState = Keyboard.GetState();
        }

        public int GetHorizontal()
        {
            KeyboardState currentState = Keyboard.GetState();
            int direction = 0;
            if (currentState.IsKeyDown(Keys.Left) || currentState.IsKeyDown(Keys.A))
            {
                direction -= 1;
            }
            if (currentState.IsKeyDown(Keys.Right) || currentState.IsKeyDown(Keys.D))
            {
                direction += 1;
            }

            return direction;
        }

        public bool IsKeyPressed(Keys key)
        {
            KeyboardState currentState = Keyboard.GetState();

            bool isKeyPressed = false;
            if (currentState.IsKeyDown(key) && previousState.IsKeyUp(key))
                isKeyPressed = true;

            previousState = currentState;
            return isKeyPressed;
        }
    }
}
