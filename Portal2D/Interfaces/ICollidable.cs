using Microsoft.Xna.Framework;

namespace Portal2D.Interfaces
{
    interface ICollidable
    {
        public bool SafeForFutureCollision { get; set; }
        public bool SafeForFalling { get; set; }
        public ICollisionTrigger CollisionTrigger { get; set; }

        public bool IsTrigger { get; set; }

        public Rectangle HitBox { get; set; }
    }
}
