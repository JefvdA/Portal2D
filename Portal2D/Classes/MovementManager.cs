using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes
{
    static class MovementManager
    {
        public static void Move(IMovable moveable)
        {
            var direction = moveable.InputReader.ReadInput();
            var afstand = direction* moveable.Speed;
            moveable.Position += direction;
        }

    }
}
