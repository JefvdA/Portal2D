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
    class Enemy : IGameObject, IMoveable, ICollidable
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Rectangle HitBox { get; set; }
        public float Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public bool SafeForFutureCollision { get; set; } = false;
        public bool SafeForFalling { get; set; } = true;
        public bool IsTrigger { get; set; } = false;
        public ICollisionTrigger CollisionTrigger { get; set; }


        private Animation animation;

        public Enemy(Texture2D _texture, IInputReader inputreader)
        {
            InputReader = inputreader;
            texture = _texture;
            Position = new Vector2(250, 100);
            Speed = 10;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 6, 1);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 400, 400);

            CollisionTrigger = new DefaultCollisionTrigger();
        }
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);

            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 400, 400);
            Fall();
            Move();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public void Fall()
        {
            MovementManager.Fall(this);
        }
        public void Move()
        {
            MovementManager.MoveHorizontal(this);
        }
    }
}
