using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Implementations;
using Portal2D.Interfaces;

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

        public PickUps(Texture2D _pickUpTexture, Vector2 position, pickUp pickUp)
        {
            pickUpTexture = _pickUpTexture;
            Position = position;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, pickUpTexture.Width/3, pickUpTexture.Height/3);
            switch (pickUp)
            {
                case pickUp.Healthboost:
                    CollisionTrigger = new ExtraHealthCollisionTrigger(this);
                    break;
                case pickUp.Invincibility:
                    CollisionTrigger = new InvincibilityCollisionTrigger(this);
                    break;
                case pickUp.collectible:
                    CollisionTrigger = new PickUpCollisionTrigger(this);
                    break;
                default:
                    break;
            }
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
    enum pickUp
    {
        Healthboost,
        Invincibility,
        collectible
    }

}


