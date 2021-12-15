using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Portal2D.Interfaces;
using System.Diagnostics;

namespace Portal2D.Classes.Managers
{
    static class MovementManager
    {
        public static void MoveHorizontal(IMoveable moveable)
        {
            var direction = moveable.InputReader.GetHorizontal();
            var distance = new Vector2(direction * moveable.Speed, 0);
            var futurePosition = moveable.Position + distance;
            if (futurePosition.X < (GameManager.ScreenWidth - 256) && futurePosition.X > 0)
            {
                if (moveable is ICollidable collidable)
                {
                    if (collidable.SafeForFutureCollision)
                        moveable.Position += new Vector2(distance.X, 0);
                }
                else
                    moveable.Position += new Vector2(distance.X, 0);
            }
        }

        public static void Jump(IJumpable jumpable)
        {
            bool hasJumped = jumpable.InputReader.IsKeyPressed(Keys.Space);
            var distance = new Vector2(0, 0);

            if (hasJumped)
                jumpable.IsJumping = true;

            if (jumpable.IsJumping && jumpable.CanJump && jumpable.JumpCounter < jumpable.JumpHeight)
            {
                var jumpForce = jumpable.JumpHeight / 4;
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

            if (futurePosition.Y < (GameManager.ScreenHeight - 256))
            {
                jumpable.Position += new Vector2(0, distance.Y);
            }

            futurePosition.Y += 7;
            if (futurePosition.Y > (GameManager.ScreenHeight - 256))
                jumpable.CanJump = true;
        }

        public static void Fall(IMoveable moveable)
        {
            var distance = new Vector2(0, 10);

            var futurePosition = moveable.Position + distance;
            if(futurePosition.Y < (GameManager.ScreenHeight - 256))
            {
                if (moveable is ICollidable collidable)
                {
                    if (collidable.SafeForFalling)
                        moveable.Position += new Vector2(0, distance.Y);
                }
                else
                    moveable.Position += new Vector2(0, distance.Y);
            }
        }

        public static Vector2 PredictMoveHorizontal(IMoveable moveable)
        {
            var direction = moveable.InputReader.GetHorizontal();
            var distance = new Vector2(direction * moveable.Speed, 0);
            var futurePosition = moveable.Position + distance;

            return futurePosition;
        }

        public static Vector2 PredictFall(IMoveable moveable)
        {
            var distance = new Vector2(0, 10);
            var futurePosition = moveable.Position + distance;

            return futurePosition;
        }

    }
}
