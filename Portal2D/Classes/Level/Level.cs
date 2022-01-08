using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Classes.Enemies;
using Portal2D.Classes.Main;
using Portal2D.Classes.Main.Spritesheet;
using Portal2D.Classes.Managers;
using Portal2D.Classes.Player;
using Portal2D.Classes.PickUp;
using Portal2D.Implementations;
using Portal2D.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Portal2D.Classes.Level
{
    public class Level
    {
        public int score = 0;

        private int lives = 3;
        public double InvincibleTimer = 3;
        private double elapsedTime = 0;
        private bool vulnerable = true;

        // Reference to player
        private Hero hero;
        private Enemy enemy1;
        private Enemy enemy2;
        private Trap trap;
        private PickUps pickUp;

        private Texture2D basicEnemyTexture;
        private Texture2D advancedEnemyTexture;
        private Texture2D heroRunningTexture;
        private Texture2D heroIdleTexture;
        private Texture2D spriteSheetTexture;
        private Texture2D trapTexture;
        private Texture2D pickUpTexture;

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
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  18,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  18,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
            {  17,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  19, },
        };

        public Level(Texture2D backGround, Texture2D spritesheetTexture, Texture2D heroRunningTexture, Texture2D heroIdleTexture, Texture2D basicEnemyTexture, Texture2D advancedEnemyTexture, Texture2D trapTexture, Texture2D pickUpTexture)
        {
            GameObjects = new List<IGameObject>();

            this.backGround = backGround;
            this.heroRunningTexture = heroRunningTexture;
            this.heroIdleTexture = heroIdleTexture;
            this.spriteSheetTexture = spritesheetTexture;
            this.basicEnemyTexture= basicEnemyTexture;
            this.advancedEnemyTexture = advancedEnemyTexture;
            this.trapTexture = trapTexture;
            this.pickUpTexture = pickUpTexture;

            this.spriteSheet = new Spritesheet();
            spriteSheet.GetItemsFromProperties(256, 256, 16, 16);

            hero = new Hero(heroRunningTexture,heroIdleTexture, new KeyboardReader());
            enemy1 = new BasicEnemy(this.basicEnemyTexture, new Vector2(750, 860), 500, 1000);
            enemy2 = new AdvancedEnemy(this.advancedEnemyTexture, new Vector2(1200, 860), hero);
            trap = new Trap(trapTexture, new Vector2(200, 1000));
            pickUp = new PickUps(pickUpTexture);
            AddGameObject(enemy1);
            AddGameObject(enemy2);
            AddGameObject(hero);
            AddGameObject(trap);
            AddGameObject(pickUp);

            CreateTiles();
        }

        public void Update(GameTime gameTime)
        {
            if (lives <= 0)
                GameManager._gameState = GameState.GameOver;
            double ElapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            if (!vulnerable)
            {
                elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            }
            if(InvincibleTimer < elapsedTime)
            {
                elapsedTime = 0;
                vulnerable = true;
            }

            // Check collisions - TRIGGER - HORIZONTAL *FOR PLAYER*
            foreach (IGameObject gameObject in GameObjects)
            {
                if (gameObject is ICollidable collidableObject)
                {
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

            // Check collisions - FALLING - JUMPING *FOR PLAYER*
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

            // Check collisions *FOR ENEMIES*
            List<Enemy> enemies = new List<Enemy>();
            foreach (IGameObject gameObject in GameObjects)
            {
                if (gameObject is Enemy enemy)
                    enemies.Add(enemy);
            }
            foreach(Enemy enemy in enemies)
            {
                foreach (IGameObject gameObject in GameObjects)
                {
                    if (gameObject is ICollidable collidableObject)
                    {
                        bool futureCollision = CollisionManager.CheckCollision(enemy.PredictCollision(), collidableObject.HitBox) && !collidableObject.IsTrigger && collidableObject != hero;

                        if (futureCollision)
                        {
                            enemy.CanMove = false;
                            break;
                        }
                        else
                            enemy.CanMove = true;
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
            for (int i = 0; i < lives; i++)
            {
                spriteBatch.Draw(Game1._heart, new Vector2(75 * i, 0), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            }
            spriteBatch.DrawString(Game1._score, "Score : " + score.ToString(), new Vector2(1000, 0), Color.White);
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
                    var posX = x * 96;
                    var posY = y * 96;
                    AddGameObject(new Tile(spriteSheetTexture, sourceRectangle, new Vector2(posX, posY), false, new DefaultCollisionTrigger()));
                }
            }
        }

        public void reset()
        {
            GameObjects = new List<IGameObject>();

            this.spriteSheet = new Spritesheet();
            spriteSheet.GetItemsFromProperties(256, 256, 16, 16);

            hero = new Hero(heroRunningTexture, heroIdleTexture, new KeyboardReader());
            this.lives = 3;
            this.vulnerable = true;
            this.score = 0;
            enemy1 = new BasicEnemy(this.basicEnemyTexture, new Vector2(750, 860), 500, 1000);
            enemy2 = new AdvancedEnemy(this.advancedEnemyTexture, new Vector2(1200, 860), hero);
            trap = new Trap(trapTexture, new Vector2(200, 1000));
            pickUp = new PickUps(pickUpTexture);
            AddGameObject(enemy1);
            AddGameObject(enemy2);
            AddGameObject(hero);
            AddGameObject(trap);
            AddGameObject(pickUp);

            CreateTiles();
        }

        public void LoseLive()
        {
            if (vulnerable)
            {
                lives--;
                vulnerable = false;
            }
        }

        public bool IsVulnerable()
        {
            return vulnerable;
        }
    }
}
