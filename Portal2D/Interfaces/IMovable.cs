namespace Portal2D.Interfaces
{
    interface IMovable : IGameObject
    {
        public float Speed { get; set; }
        public IInputReader InputReader { get; set; }
    }
}
