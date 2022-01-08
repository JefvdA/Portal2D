namespace Portal2D.Interfaces
{
    public interface IMoveable : IGameObject
    {
        public float Speed { get; set; }
        public IInputReader InputReader { get; set; }
    }
}
