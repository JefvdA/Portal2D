using Microsoft.Xna.Framework;

namespace Portal2D.Interfaces
{
    interface IMovable
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public IInputReader InputReader { get; set; }
    }
}
