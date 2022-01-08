using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Implementations;
using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.PickUp
{
    class PickUps : ICollidable, IGameObject
    {
        private Texture2D pickUpTexture;
        public bool pickedUp = false;
        public bool SafeForFutureCollision { get; set; }
        public bool SafeForFalling { get; set; }
        public ICollisionTrigger CollisionTrigger { get; set; }
        public bool IsTrigger { get; set; } = true;
        public Rectangle HitBox { get; set; }
        public Vector2 Position { get; set; }

        public PickUps(Texture2D _pickUpTexture)
        {
            pickUpTexture = _pickUpTexture;
            CollisionTrigger = new PickUpCollisionTrigger(this);
            Position = new Vector2(1000, 700);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, pickUpTexture.Width/3, pickUpTexture.Height/3);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!pickedUp)
                spriteBatch.Draw(pickUpTexture, Position, new Rectangle(0, 0, pickUpTexture.Width, pickUpTexture.Height), Color.White, 0f, Vector2.Zero, .33f, SpriteEffects.None, 0f);
        }
    }

}


