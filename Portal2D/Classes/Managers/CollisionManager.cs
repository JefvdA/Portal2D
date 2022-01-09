using Microsoft.Xna.Framework;
using Portal2D.Interfaces;

namespace Portal2D.Classes.Managers
{
    static class CollisionManager
    {
        public static bool CheckCollision(Rectangle hitbox1, Rectangle hitbox2)
        {
            if (hitbox1.Intersects(hitbox2))
                return true;

            return false;
        }

        public static Rectangle PredictCollisionHorizontal<T>(T gameObject) 
            where T : ICollidable, IMoveable
        {
            Vector2 futurePosition = MovementManager.Instance().PredictMoveHorizontal(gameObject);

            Rectangle futureHitBox = new Rectangle((int)futurePosition.X, (int)futurePosition.Y, gameObject.HitBox.Width, gameObject.HitBox.Height);
            return futureHitBox;
        }

        public static Rectangle PredictFallCollision<T>(T gameObject)
            where T : ICollidable, IMoveable
        {
            Vector2 futurePosition = MovementManager.Instance().PredictFall(gameObject);

            Rectangle futureHitBox = new Rectangle((int)futurePosition.X, (int)futurePosition.Y, gameObject.HitBox.Width, gameObject.HitBox.Height);
            return futureHitBox;
        }

        public static Rectangle PredictJumpCollision<T>(T gameObject)
            where T: ICollidable, IJumpable
        {
            Vector2 futurePosition = MovementManager.Instance().PredictJump(gameObject);

            Rectangle futureHitBox = new Rectangle((int)futurePosition.X, (int)futurePosition.Y, gameObject.HitBox.Width, gameObject.HitBox.Height);
            return futureHitBox;
        }
    }
}
