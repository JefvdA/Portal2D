using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Classes.Managers;
using Portal2D.Classes.Player;
using Portal2D.Implementations;
using Portal2D.Interfaces;
using System.Collections.Generic;

namespace Portal2D.Classes.Level
{
    public class Level
    {
        // Reference to player
        private Hero hero;
        private Texture2D heroTexture;

        private Texture2D backGround;
        public List<IGameObject> GameObjects { get; private set; }

        public Level(Texture2D backGround, Texture2D heroTexture)
        {
            this.backGround = backGround;
            this.heroTexture = heroTexture;
            this.GameObjects = new List<IGameObject>();

            hero = new Hero(heroTexture, new KeyboardReader());
            AddGameObject(hero);
        }

        public void Update(GameTime gameTime)
        {
            // Check collisions
            foreach (IGameObject gameObject in GameObjects)
            {
                if (gameObject is ICollidable)
                {
                    ICollidable collidableObject = (ICollidable)gameObject;

                    bool playerCollision = CollisionManager.CheckCollision(hero.HitBox, collidableObject.HitBox) && collidableObject != hero && collidableObject.IsTrigger;
                    if (playerCollision)
                    {
                        // Player is CURRENTLY inside of an object WHICH IS A TRIGGER
                        collidableObject.CollisionTrigger.OnTrigger();
                    }

                    bool futurePlayerCollisionJumping = CollisionManager.CheckCollision(CollisionManager.PredictJumpCollision(hero), collidableObject.HitBox) && collidableObject != hero && !collidableObject.IsTrigger;
                    bool futurePlayerCollisionFalling = CollisionManager.CheckCollision(CollisionManager.PredictFallCollision(hero), collidableObject.HitBox) && collidableObject != hero && !collidableObject.IsTrigger;
                    bool futurePlayerCollisionHorizontal = CollisionManager.CheckCollision(CollisionManager.PredictCollisionHorizontal(hero), collidableObject.HitBox) && collidableObject != hero && !collidableObject.IsTrigger;
                    bool futurePlayerCollision = futurePlayerCollisionFalling || futurePlayerCollisionHorizontal || futurePlayerCollisionJumping;
                    if (futurePlayerCollision)
                    {
                        // Player WILL BE inside of an object NEXT FRAME
                        if (futurePlayerCollisionJumping)
                            hero.CanJump = false;
                        if (futurePlayerCollisionHorizontal)
                            hero.SafeForFutureCollision = false;
                        if (futurePlayerCollisionFalling)
                        {
                            hero.SafeForFalling = false;
                            hero.CanJump = true;
                        }
                        continue;
                    }
                    else
                    {
                        if (!futurePlayerCollisionHorizontal)
                            hero.SafeForFutureCollision = true;
                        if (!futurePlayerCollisionFalling)
                            hero.SafeForFalling = true;
                    }
                }
            }

            // Update each gameObject
            foreach (IGameObject gameObject in GameObjects)
            {
                gameObject.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, new Vector2(0, 0), Color.White);

            foreach (var gameObject in GameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }

        public void AddGameObject(IGameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }
    }
}
