using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Portal2D.Interfaces;

namespace Portal2D.Classes.Main
{
    class MouseReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            MouseState state = Mouse.GetState();
            Vector2 positionMouse = new Vector2(state.X, state.Y);
            return positionMouse;
        }
    }
}
