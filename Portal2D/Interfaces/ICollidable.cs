using Microsoft.Xna.Framework;

namespace Portal2D.Interfaces
{
    interface ICollidable
    {
        public ICollisionTrigger CollisionTrigger { get; set; }

        public bool IsTrigger { get; set; }

        public Rectangle HitBox { get; set; }
    }
}
