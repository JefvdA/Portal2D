﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Portal2D.Classes.Main;
using Portal2D.Classes.Managers;
using Portal2D.Classes.Player;
using Portal2D.Interfaces;
using Portal2D.Implementations;
using System.Collections.Generic;
using System.Diagnostics;
using Portal2D.Classes.Level;
using Portal2D.Classes.Menu;

namespace Portal2D
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const bool SHOW_HITBOXES = true;

        // Reference to player
        private Hero hero;

        // Reference to Level
        private Level1 level1;

        //Reference to Menu
        private Menu menu;

        // Variables for textures
        private Texture2D _background;
        private Texture2D _heroTexture;
        private Texture2D _blockTexture;

        private List<IGameObject> gameObjects = new List<IGameObject>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            hero = new Hero(_heroTexture, new KeyboardReader());
            level1 = new Level1(_background);
            menu = new Menu(_background);

            gameObjects.Add(hero);
            //gameObjects.Add(new Block(_blockTexture, Color.Green, 5, new Vector2(150, 150), true, new ChangeBGColorCollisionTrigger(Color.LightGreen)));
            //gameObjects.Add(new Block(_blockTexture, Color.Red, 5, new Vector2(650, 150), true, new ChangeBGColorCollisionTrigger(Color.DarkRed)));
            //gameObjects.Add(new Block(_blockTexture, Color.Blue, 5, new Vector2(400, 150), true, new ChangeBGColorCollisionTrigger(Color.CornflowerBlue)));
            gameObjects.Add(new Block(_blockTexture, Color.Black, 10, new Vector2(500, 400), false, new DefaultCollisionTrigger()));

            //uncomment for fullscreen
            //_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //_graphics.ToggleFullScreen();
            //_graphics.ApplyChanges();

            GameManager.ScreenWidth = GraphicsDevice.Viewport.Width;
            GameManager.ScreenHeight = GraphicsDevice.Viewport.Height;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _blockTexture = new Texture2D(GraphicsDevice, 1, 1);
            _blockTexture.SetData(new[] { Color.White });
            _heroTexture = Content.Load<Texture2D>("Character_run");
            _background = Content.Load<Texture2D>("Background");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Check collisions
            foreach (IGameObject gameObject in gameObjects)
            {
                if (gameObject is ICollidable)
                {
                    ICollidable collidableObject = (ICollidable)gameObject;

                    bool playerCollision= CollisionManager.CheckCollision(hero.HitBox, collidableObject.HitBox) && collidableObject != hero && collidableObject.IsTrigger;
                    if (playerCollision)
                    {
                        // Player is CURRENTLY inside of an object WHICH IS A TRIGGER
                        collidableObject.CollisionTrigger.OnTrigger();
                    }

                    bool futurePlayerCollisionFalling = CollisionManager.CheckCollision(CollisionManager.PredictFallCollision(hero), collidableObject.HitBox) && collidableObject != hero && !collidableObject.IsTrigger;
                    bool futurePlayerCollisionHorizontal = CollisionManager.CheckCollision(CollisionManager.PredictCollisionHorizontal(hero), collidableObject.HitBox) && collidableObject != hero && !collidableObject.IsTrigger;
                    bool futurePlayerCollision = futurePlayerCollisionFalling || futurePlayerCollisionHorizontal;
                    if (futurePlayerCollision)
                    {
                        // Player WILL BE inside of an object NEXT FRAME
                        if(futurePlayerCollisionHorizontal)
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
                        if(!futurePlayerCollisionHorizontal)
                            hero.SafeForFutureCollision = true;
                        if (!futurePlayerCollisionFalling)
                            hero.SafeForFalling = true;
                    }
                }
            }

            // Update each gameObject
            foreach (IGameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            level1.Draw(_spriteBatch);
            foreach (IGameObject gameObject in gameObjects)
            {
                gameObject.Draw(_spriteBatch);

                if (gameObject is ICollidable && SHOW_HITBOXES)
                {
                    ICollidable collidableObject = (ICollidable)gameObject;
                    _spriteBatch.Draw(_blockTexture, collidableObject.HitBox, Color.Green * 0.5f);
                }
            }
            //menu.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
