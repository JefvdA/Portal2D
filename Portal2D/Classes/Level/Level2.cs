﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Classes.Enemies;
using Portal2D.Classes.PickUp;

namespace Portal2D.Classes.Level
{
    public class Level2 : Level
    {
        // Reference to gameObjects
        private Enemy enemy1;
        private Enemy enemy2;
        private Trap trap;
        private PickUps pickUp;
        private PickUps pickUp2;


        public Level2(Texture2D backGround, Texture2D spritesheetTexture, Texture2D heroRunningTexture, Texture2D heroIdleTexture, Texture2D basicEnemyTexture, Texture2D advancedEnemyTexture, Texture2D trapTexture, Texture2D pickUpTexture) : base(backGround, spritesheetTexture, heroRunningTexture, heroIdleTexture, basicEnemyTexture, advancedEnemyTexture, trapTexture, pickUpTexture)
        {
            enemy1 = new BasicEnemy(this.basicEnemyTexture, new Vector2(1600, 860), 800, 1800);
            enemy2 = new AdvancedEnemy(this.advancedEnemyTexture, new Vector2(800, 290), hero);
            trap = new Trap(trapTexture, new Vector2(200, 1000));
            pickUp = new PickUps(pickUpTexture, new Vector2(150, 120));
            pickUp2 = new PickUps(pickUpTexture, new Vector2(1800, 950));
            scoreNeeded = 2;

            AddGameObject(enemy1);
            AddGameObject(enemy2);
            AddGameObject(trap);
            AddGameObject(pickUp);
            AddGameObject(pickUp2);

            // Initiate the level with the gameboard
            this.gameBoard = new int[,]
            {
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,   1,   3,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  24,  34,  30,  -1,  -1,  -1,  -1, },
                {   1,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,  50,   2,   3,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,   1,  2, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, },
                {  17,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  19, },
            };
            CreateTiles();
        }

        public override void reset()
        {
            base.reset();

            enemy1 = new BasicEnemy(this.basicEnemyTexture, new Vector2(1600, 860), 800, 1800);
            enemy2 = new AdvancedEnemy(this.advancedEnemyTexture, new Vector2(800, 290), hero);
            trap = new Trap(trapTexture, new Vector2(200, 1000));
            pickUp = new PickUps(pickUpTexture, new Vector2(150, 120));
            pickUp2 = new PickUps(pickUpTexture, new Vector2(1800, 950));
            scoreNeeded = 2;

            AddGameObject(enemy1);
            AddGameObject(enemy2);
            AddGameObject(trap);
            AddGameObject(pickUp);
            AddGameObject(pickUp2);
        }
    }
}
