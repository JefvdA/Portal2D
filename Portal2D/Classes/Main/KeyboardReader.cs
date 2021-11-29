using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Portal2D.Interfaces;

namespace Portal2D.Classes.Main
{
    class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.A))
            {
                direction.X -= 10;
            }
            if (state.IsKeyDown(Keys.D))
            {
                direction.X += 10;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                // TODO : JUMP
            }
            return direction;
        }
    }
}
