using Microsoft.Xna.Framework;

namespace Portal2D.Interfaces
{
    interface ICollidable
    {
        public Rectangle HitBox { get; set; }

        public bool CheckCollision(ICollidable other)
        {
            if (HitBox.Intersects(other.HitBox))
                return true;

            return false;
        }
    }
}
