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

        public static Rectangle PredictCollision<T>(T gameObject) 
            where T : ICollidable, IMovable
        {
            Vector2 futurePosition = MovementManager.PredictMove(gameObject);

            Rectangle futureHitBox = new Rectangle((int)futurePosition.X, (int)futurePosition.Y, gameObject.HitBox.Width, gameObject.HitBox.Height);
            return futureHitBox;
        }
    }
}
