namespace Portal2D.Interfaces
{
    internal interface IJumpable : IMovable
    {
        public bool CanJump { get; set; }
        public float JumpHeight { get; set; }
        public float JumpCounter { get; set; }
    }
}
