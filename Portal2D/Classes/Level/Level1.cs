using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Classes.Enemies;
using Portal2D.Classes.PickUp;

namespace Portal2D.Classes.Level
{
    public class Level1 : Level
    {
        // Reference to gameObjects
        private Enemy enemy1;
        private Trap trap;
        private PickUps pickUp;
        private PickUps pickUp2;
        private PickUps powerUp;


        public Level1(Texture2D backGround, Texture2D spritesheetTexture, Texture2D heroRunningTexture, Texture2D heroIdleTexture, Texture2D basicEnemyTexture, Texture2D advancedEnemyTexture, Texture2D trapTexture) : base(backGround, spritesheetTexture, heroRunningTexture, heroIdleTexture, basicEnemyTexture, advancedEnemyTexture, trapTexture)
        {
            enemy1 = new BasicEnemy(this.basicEnemyTexture, new Vector2(800, 865), 600, 1300);
            trap = new Trap(trapTexture, new Vector2(200, 1000));
            pickUp = new PickUps(Game1._pickUp, new Vector2(700, 500), PickUp.pickUp.collectible);
            pickUp2 = new PickUps(Game1._pickUp, new Vector2(1800, 950), PickUp.pickUp.collectible);
            powerUp = new PickUps(Game1._powerUpHealth, new Vector2(1800, 200), PickUp.pickUp.Healthboost);
            scoreNeeded = 2;
            AddGameObject(enemy1);
            AddGameObject(trap);
            AddGameObject(pickUp);
            AddGameObject(pickUp2);
            AddGameObject(powerUp);

            // Initiate the level with the gameboard
            this.gameBoard = new int[,]
            {
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,   1,   2,   2,   2,   2,   2,   3,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,   1,   3,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,   1,   2, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  17,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  19, },
            };
            CreateTiles();
        }

        public override void reset()
        {
            base.reset();

            enemy1 = new BasicEnemy(this.basicEnemyTexture, new Vector2(800, 865), 600, 1300);
            trap = new Trap(trapTexture, new Vector2(200, 1000));
            pickUp = new PickUps(Game1._pickUp, new Vector2(700, 500), PickUp.pickUp.collectible);
            pickUp2 = new PickUps(Game1._pickUp, new Vector2(1800, 950), PickUp.pickUp.collectible);
            powerUp = new PickUps(Game1._powerUpHealth, new Vector2(1800, 200), PickUp.pickUp.Healthboost);
            scoreNeeded = 2;
            AddGameObject(enemy1);
            AddGameObject(trap);
            AddGameObject(pickUp);
            AddGameObject(pickUp2);
            AddGameObject(powerUp);

        }
    }
}
