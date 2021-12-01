using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Portal2D.Interfaces;

namespace Portal2D.Implementations
{
    class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.None)) 
            { 
                // TODO : idle state
            }
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 10;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 10;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                direction.Y -= 4;
            }
            return direction;
        }
    }
}
