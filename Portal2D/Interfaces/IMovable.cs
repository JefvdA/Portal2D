using Microsoft.Xna.Framework;

namespace Portal2D.Interfaces
{
    interface IMovable
    {
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }
    }
}
