using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Interfaces;

namespace Portal2D.Classes.Main
{
    internal class Tile : IGameObject, ICollidable
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;

        public Vector2 Position { get; set; }

        public bool SafeForFutureCollision { get; set; }
        public bool SafeForFalling { get; set; }
        public ICollisionTrigger CollisionTrigger { get; set; }
        public bool IsTrigger { get; set; }
        public Rectangle HitBox { get; set; }


        public Tile(Texture2D texture, Rectangle sourceRectangle, Vector2 position, bool isTrigger, ICollisionTrigger collisionTrigger)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
            Position = position;
            IsTrigger = isTrigger;
            CollisionTrigger = collisionTrigger;

            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 96, 96);

            CollisionTrigger = collisionTrigger;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, sourceRectangle, Color.White, 0f, Vector2.Zero, 6f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime) {}
    }
}
