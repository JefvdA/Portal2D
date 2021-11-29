using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.Main
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
