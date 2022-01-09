namespace Portal2D.Interfaces
{
    public interface IJumpable : IMoveable
    {
        public bool CanJump { get; set; }
        public bool IsJumping { get; set; }
        public float JumpHeight { get; set; }
        public float JumpCounter { get; set; }
    }
}
