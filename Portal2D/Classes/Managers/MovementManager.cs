using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Portal2D.Interfaces;

namespace Portal2D.Classes.Managers
{
    public class MovementManager
    {
        private volatile static MovementManager instance;
        private MovementManager() { }

        public static MovementManager Instance()
        {
            if (instance == null)
            {
                instance = new MovementManager();
            }
            return instance;
        }

        public void MoveHorizontal(IMoveable moveable)
        {
            var direction = moveable.InputReader.GetHorizontal();
            var distance = new Vector2(direction * moveable.Speed, 0);
            var futurePosition = moveable.Position + distance;
            if (futurePosition.X < (GameManager.ScreenWidth - 128) && futurePosition.X > 0)
            {
                if (moveable is ICollidable collidable)
                {
                    if (collidable.SafeForFutureCollision)
                        moveable.Position += new Vector2(distance.X, 0);
                }
                else
                    moveable.Position += new Vector2(distance.X, 0);
            }
            else
            {
                distance = new Vector2(direction, 0);
                futurePosition = moveable.Position + distance;

                if (futurePosition.X < (GameManager.ScreenWidth - 128) && futurePosition.X > 0)
                    moveable.Position += new Vector2(distance.X, 0);
            }
        }

        public void Jump(IJumpable jumpable)
        {
            bool hasJumped = jumpable.InputReader.IsKeyPressed(Keys.Space);
            var distance = new Vector2(0, 0);

            if (hasJumped)
                jumpable.IsJumping = true;

            if (jumpable.IsJumping && jumpable.CanJump && jumpable.JumpCounter < jumpable.JumpHeight)
            {
                var jumpForce = jumpable.JumpHeight / 12;
                distance = new Vector2(0, -jumpForce);
                jumpable.JumpCounter += jumpForce;
            }
            else
            {
                jumpable.CanJump = false;
                jumpable.IsJumping = false;
                jumpable.JumpCounter = 0;
            }
            var futurePosition = jumpable.Position + distance;

            if (futurePosition.Y < (GameManager.ScreenHeight - 128))
            {
                jumpable.Position += new Vector2(0, distance.Y);
            }

            futurePosition = PredictFall(jumpable);
            if (futurePosition.Y > (GameManager.ScreenHeight - 128))
                jumpable.CanJump = true;
        }

        public void Fall(IMoveable moveable)
        {
            var distance = new Vector2(0, GameManager.Gravity);

            var futurePosition = moveable.Position + distance;
            if(futurePosition.Y < (GameManager.ScreenHeight - 128))
            {
                if (moveable is ICollidable collidable)
                {
                    if (collidable.SafeForFalling)
                        moveable.Position += new Vector2(0, distance.Y);
                }
                else
                    moveable.Position += new Vector2(0, distance.Y);
            }
            else
            {
                distance = new Vector2(0, 1);
                futurePosition = moveable.Position + distance;

                if (futurePosition.Y < (GameManager.ScreenHeight - 128))
                    moveable.Position += new Vector2(0, distance.Y);
            }
        }

        public Vector2 PredictMoveHorizontal(IMoveable moveable)
        {
            var direction = moveable.InputReader.GetHorizontal();
            var distance = new Vector2(direction * moveable.Speed, 0);
            var futurePosition = moveable.Position + distance;

            return futurePosition;
        }

        public Vector2 PredictFall(IMoveable moveable)
        {
            var distance = new Vector2(0, GameManager.Gravity);
            var futurePosition = moveable.Position + distance;

            return futurePosition;
        }

        public Vector2 PredictJump(IJumpable jumpable)
        {
            var jumpForce = jumpable.JumpHeight / 12;
            var distance = new Vector2(0, -jumpForce);
            var futurePosition = jumpable.Position + distance;

            return futurePosition;
        }
    }
}
