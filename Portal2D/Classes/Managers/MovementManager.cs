using Microsoft.Xna.Framework;
using Portal2D.Interfaces;
using System.Diagnostics;

namespace Portal2D.Classes.Managers
{
    static class MovementManager
    {
        public static void Move(IMovable moveable)
        {
            var direction = moveable.InputReader.ReadInput();
            var distance = new Vector2(direction.X * moveable.Speed, 0);

            if (moveable is IJumpable jumpable)
            {

                Debug.WriteLine(jumpable.CanJump);

                if (direction.Y == -1 && jumpable.CanJump)
                {
                    jumpable.Position = new Vector2(jumpable.Position.X, jumpable.Position.Y - jumpable.JumpHeight);

                    jumpable.CanJump = false; 
                }
            }

            distance.Y += 5;

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
            if (futurePosition.Y < (GameManager.ScreenHeight - 256))
            {
                if (moveable is ICollidable collidable)
                {
                    if (collidable.SafeForFutureCollision)
                        moveable.Position += new Vector2(0, distance.Y);
                }
                else
                    moveable.Position += new Vector2(0, distance.Y);
            }

            if (futurePosition.Y > (GameManager.ScreenHeight - 256) && moveable is IJumpable jumpable1)
                jumpable1.CanJump = true;
        }

        public static Vector2 PredictMove(IMovable moveable)
        {
            var direction = moveable.InputReader.ReadInput();

            var distance = new Vector2(direction.X * moveable.Speed, 0);
            distance.Y += 5;
            var futurePosition = moveable.Position + distance;

            return futurePosition;
        }

    }
}
