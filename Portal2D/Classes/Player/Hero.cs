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
        private int previous = 1;

        private Texture2D RunningTexture;
        private Texture2D IdleTexture;
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public Rectangle HitBox { get; set; }

        private Animation animation;
        private Animation animation2;

        public bool SafeForFutureCollision { get; set; } = false;
        public bool SafeForFalling { get; set; } = true;
        public bool IsTrigger { get; set; } = false;
        public ICollisionTrigger CollisionTrigger { get; set; }
        public bool CanJump { get; set; }
        public float JumpHeight { get; set; }
        public float JumpCounter { get; set; }
        public bool IsJumping { get; set; }

        public Hero(Texture2D runningTexture, Texture2D idleTexture, IInputReader inputReader)
        {
            this.RunningTexture = runningTexture;
            this.IdleTexture = idleTexture;
            InputReader = inputReader;

            animation = new Animation();
            animation.GetFramesFromTextureProperties(RunningTexture.Width, RunningTexture.Height, 6, 1);
            animation2 = new Animation();
            animation2.GetFramesFromTextureProperties(IdleTexture.Width,IdleTexture.Height, 4, 1);

            Position = new Vector2(250, 100);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 128, 128);
            Speed = 10f;
            JumpHeight = 400f;
            CanJump = true;

            CollisionTrigger = new DefaultCollisionTrigger();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (InputReader.GetHorizontal() != 0) 
            {
                previous = InputReader.GetHorizontal();
            }

            if (InputReader.GetHorizontal() == 1)
            {
                spriteBatch.Draw(RunningTexture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
            }
            else if (InputReader.GetHorizontal() == -1)
            {
                spriteBatch.Draw(RunningTexture, new Vector2(Position.X - 60, Position.Y), animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.FlipHorizontally, 0f);
            }
            else if (InputReader.GetHorizontal() == 0 && previous == 1)
            {
                spriteBatch.Draw(IdleTexture, new Vector2(Position.X, Position.Y - 60), animation2.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
            }
            else if (InputReader.GetHorizontal() == 0 && previous == -1)
            {
                spriteBatch.Draw(IdleTexture, new Vector2(Position.X - 60, Position.Y - 60), animation2.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.FlipHorizontally, 0f);
            }

        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            animation2.Update(gameTime);

            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 128, 128);

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
