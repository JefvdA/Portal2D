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
        //private Enemy enemy2;
        private Trap trap;
        private PickUps pickUp;

        public Level1(Texture2D backGround, Texture2D spritesheetTexture, Texture2D heroRunningTexture, Texture2D heroIdleTexture, Texture2D basicEnemyTexture, Texture2D advancedEnemyTexture, Texture2D trapTexture, Texture2D pickUpTexture) : base(backGround, spritesheetTexture, heroRunningTexture, heroIdleTexture, basicEnemyTexture, advancedEnemyTexture, trapTexture, pickUpTexture)
        {
            enemy1 = new BasicEnemy(this.basicEnemyTexture, new Vector2(750, 1000), 800, 1200);
            //enemy2 = new AdvancedEnemy(this.advancedEnemyTexture, new Vector2(1200, 860), hero);
            trap = new Trap(trapTexture, new Vector2(200, 1000));
            pickUp = new PickUps(pickUpTexture, new Vector2(1000, 700));

            AddGameObject(enemy1);
            //AddGameObject(enemy2);
            AddGameObject(trap);
            AddGameObject(pickUp);

            // Initiate the level with the gameboard
            this.gameBoard = new int[,]
            {
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  17,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  19, },
            };
            CreateTiles();
        }

        public override void reset()
        {
            base.reset();

            enemy1 = new BasicEnemy(this.basicEnemyTexture, new Vector2(750, 860), 500, 1000);
            //enemy2 = new AdvancedEnemy(this.advancedEnemyTexture, new Vector2(1200, 860), hero);
            trap = new Trap(trapTexture, new Vector2(200, 1000));
            pickUp = new PickUps(pickUpTexture, new Vector2(1000, 700));

            AddGameObject(enemy1);
            //AddGameObject(enemy2);
            AddGameObject(trap);
            AddGameObject(pickUp);
        }
    }
}
