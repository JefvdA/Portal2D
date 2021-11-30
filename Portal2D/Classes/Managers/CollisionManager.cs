using Portal2D.Interfaces;

namespace Portal2D.Classes.Managers
{
    static class CollisionManager
    {
        public static bool CheckCollision(ICollidable object1, ICollidable object2)
        {
            if (object1.HitBox.Intersects(object2.HitBox))
                return true;

            return false;
        }
    }
}
