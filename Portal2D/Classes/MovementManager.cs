using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes
{
    static class MovementManager
    {
        public static void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();
            movable.Position += direction;
        }

    }
}
