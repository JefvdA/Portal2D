namespace Portal2D.Interfaces
{
    interface IMoveable : IGameObject
    {
        public float Speed { get; set; }
        public IInputReader InputReader { get; set; }
    }
}
