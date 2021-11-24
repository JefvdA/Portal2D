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

            }
            return direction;
        }
    }
}
