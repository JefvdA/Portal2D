using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Classes.Main;
using Portal2D.Classes.Main.Spritesheet;
using Portal2D.Classes.Managers;
using Portal2D.Classes.Player;
using Portal2D.Implementations;
using Portal2D.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Portal2D.Classes.Level
{
    public class Level
    {
        // Reference to player
        private Hero hero;

        private Texture2D heroRunningTexture;
        private Texture2D heroIdleTexture;
        private Texture2D spriteSheetTexture;

        private Spritesheet spriteSheet;

        private Texture2D backGround;
        public List<IGameObject> GameObjects { get; private set; }
        private int[,] gameBoard = new int[,]
        {
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, 125,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  41,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  16,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  18, },
            {  31,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  33, },
        };

        public Level(Texture2D backGround, Texture2D spritesheetTexture, Texture2D heroRunningTexture, Texture2D heroIdleTexture)
        {
            GameObjects = new List<IGameObject>();

            this.backGround = backGround;
            this.heroRunningTexture = heroRunningTexture;
            this.heroIdleTexture = heroIdleTexture;
            this.spriteSheetTexture = spritesheetTexture;

            this.spriteSheet = new Spritesheet();
            spriteSheet.GetItemsFromProperties(256, 256, 16, 16);

            hero = new Hero(heroRunningTexture,heroIdleTexture, new KeyboardReader());
            AddGameObject(hero);

            CreateTiles();
        }

        public void Update(GameTime gameTime)
        {
            // Check collisions - TRIGGER - HORIZONTAL
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

                    bool futurePlayerCollisionHorizontal = CollisionManager.CheckCollision(CollisionManager.PredictCollisionHorizontal(hero), collidableObject.HitBox) && collidableObject != hero && !collidableObject.IsTrigger;
                    hero.SafeForFutureCollision = !futurePlayerCollisionHorizontal;
                    if (futurePlayerCollisionHorizontal)
                        break;
                }
            }

            // Check collisions - FALLING - JUMPING
            foreach (IGameObject gameObject in GameObjects)
            {
                if(gameObject is ICollidable collidableObject)
                {
                    bool futurePlayerCollisionJumping = CollisionManager.CheckCollision(CollisionManager.PredictJumpCollision(hero), collidableObject.HitBox) && collidableObject != hero && !collidableObject.IsTrigger;
                    bool futurePlayerCollisionFalling = CollisionManager.CheckCollision(CollisionManager.PredictFallCollision(hero), collidableObject.HitBox) && collidableObject != hero && !collidableObject.IsTrigger;

                    hero.SafeForFalling = !futurePlayerCollisionFalling;

                    if (futurePlayerCollisionJumping)
                        hero.CanJump = false;
                    if (futurePlayerCollisionFalling)
                        hero.CanJump = true;

                    if (futurePlayerCollisionFalling || futurePlayerCollisionJumping)
                        break;
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

        private void CreateTiles()
        {
            for(int y = 0; y < gameBoard.GetLength(0); y++)
            {
                for(int x = 0; x < gameBoard.GetLength(1); x++)
                {
                    var tile = gameBoard[y, x];

                    if (tile == -1)
                        continue;

                    var sourceRectangle = spriteSheet.GetItem(tile);
                    Debug.WriteLine(sourceRectangle);
                    var posX = x * 96;
                    var posY = y * 96;
                    AddGameObject(new Tile(spriteSheetTexture, sourceRectangle, new Vector2(posX, posY), false, new DefaultCollisionTrigger()));
                }
            }
        }
    }
}
