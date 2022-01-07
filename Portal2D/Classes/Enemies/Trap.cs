using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Implementations;
using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.Enemies
{
    class Trap : IGameObject, ICollidable
    {
        private Texture2D trapTexture;
        public Vector2 Position { get; set; }
        public bool SafeForFutureCollision { get; set; }
        public bool SafeForFalling { get; set; }
        public ICollisionTrigger CollisionTrigger { get; set; }
        public bool IsTrigger { get; set; } = true;
        public Rectangle HitBox { get; set; }

        public Trap(Texture2D _trapTexture, Vector2 position)
        {
            trapTexture = _trapTexture;
            CollisionTrigger = new EnemyCollsionTrigger();
            Position = position;
            HitBox = new Rectangle((int) Position.X, (int)Position.Y, 165,85);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(trapTexture, Position, null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
