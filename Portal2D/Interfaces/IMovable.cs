using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Interfaces
{
    interface IMovable
    {
        public Vector2 Position { get; set; }
        public IInputReader InputReader { get; set; }

    }
}
