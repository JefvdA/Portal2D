using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Portal2D.Interfaces;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes
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
