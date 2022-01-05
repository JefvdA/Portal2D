using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Classes.Main.Animation;
using Portal2D.Classes.Managers;
using Portal2D.Implementations;
using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.Enemies
{
    class Enemy : IGameObject, ICollidable
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Rectangle HitBox { get; set; }
        public float Speed { get; set; }
        public bool SafeForFutureCollision { get; set; }
        public bool SafeForFalling { get; set; }
        public ICollisionTrigger CollisionTrigger { get; set; }
        public bool IsTrigger { get; set; } = true;

        public float direction;

        private Animation animation;

        public Enemy(Texture2D _texture)
        {
            CollisionTrigger = new EnemyCollsionTrigger();
            direction = 1f;
            texture = _texture;
            Position = new Vector2(500, 866);
            Speed = 5f;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 6, 1);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y+64, 128, 128);
        }
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);

            Move();
            HitBox = new Rectangle((int)Position.X, (int)Position.Y+64, 128, 128);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(direction > 0)
                spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(texture, new Vector2(Position.X - 60, Position.Y), animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.FlipHorizontally, 0f);
        }
        public void Move()
        {
            if (Position.X == 1000)
                direction = -Speed;
            if (Position.X == 500)
                direction = Speed;

            Position += new Vector2(direction, 0);
        }
    }
}
