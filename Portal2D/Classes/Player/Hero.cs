using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Classes.Main.Animation;
using Portal2D.Classes.Managers;
using Portal2D.Implementations;
using Portal2D.Interfaces;
using System.Diagnostics;

namespace Portal2D.Classes.Player
{
    class Hero : IGameObject, IMoveable, IJumpable, ICollidable
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public Rectangle HitBox { get; set; }

        private Animation animation;

        public bool SafeForFutureCollision { get; set; } = false;
        public bool SafeForFalling { get; set; } = true;
        public bool IsTrigger { get; set; } = false;
        public ICollisionTrigger CollisionTrigger { get; set; }
        public bool CanJump { get; set; }
        public float JumpHeight { get; set; }
        public float JumpCounter { get; set; }
        public bool IsJumping { get; set; }

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            InputReader = inputReader;

            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 6, 1);

            Position = new Vector2(250, 100);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 64, 64); // offset: X:30/52 Y:30/30
            Speed = 10f;
            JumpHeight = 700f;
            CanJump = true;

            CollisionTrigger = new DefaultCollisionTrigger();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);

            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 64, 64); // offset: X:30/52 Y:30/30

            Move();
            Jump();
            Fall();
        }

        public void Move()
        {
            MovementManager.MoveHorizontal(this);
        }

        public void Jump()
        {
            MovementManager.Jump(this);
        }

        public void Fall()
        {
            MovementManager.Fall(this);
        }

        public void ChangeInput(IInputReader inputReader)
        {
            InputReader = inputReader;
        }
    }
}
