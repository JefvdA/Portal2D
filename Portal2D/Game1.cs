using Microsoft.Xna.Framework;
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

            gameObjects.Add(hero);
            gameObjects.Add(new Block(_blockTexture, Color.Green, 5, new Vector2(150, 150), true, new ChangeBGColorCollisionTrigger(Color.LightGreen)));
            gameObjects.Add(new Block(_blockTexture, Color.Red, 5, new Vector2(650, 150), true, new ChangeBGColorCollisionTrigger(Color.DarkRed)));
            gameObjects.Add(new Block(_blockTexture, Color.Blue, 5, new Vector2(400, 150), true, new ChangeBGColorCollisionTrigger(Color.CornflowerBlue)));
            gameObjects.Add(new Block(_blockTexture, Color.Black, 10, new Vector2(500, 400), false, new DefaultCollisionTrigger()));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _blockTexture = new Texture2D(GraphicsDevice, 1, 1);
            _blockTexture.SetData(new[] { Color.White });
            _heroTexture = Content.Load<Texture2D>("CharacterSheet");
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

                    bool playerCollision = CollisionManager.CheckCollision(hero.HitBox, collidableObject.HitBox) && collidableObject != hero && collidableObject.IsTrigger;
                    if (playerCollision)
                    {
                        // Player is CURRENTLY inside of an object
                        collidableObject.CollisionTrigger.OnTrigger();
                    }

                    bool futurePlayerCollision = CollisionManager.CheckCollision(CollisionManager.PredictCollision(hero), collidableObject.HitBox) && collidableObject != hero && !collidableObject.IsTrigger;
                    if (futurePlayerCollision)
                    {
                        // Player WILL BE inside of an object NEXT FRAME
                        hero.SafeForFutureCollision = false;
                        continue;
                    }
                    else
                    {
                        hero.SafeForFutureCollision = true;
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
            GraphicsDevice.Clear(GameManager.backGroundColor);
            _spriteBatch.Begin();
            foreach (IGameObject gameObject in gameObjects)
            {
                gameObject.Draw(_spriteBatch);

                if (gameObject is ICollidable && SHOW_HITBOXES)
                {
                    ICollidable collidableObject = (ICollidable)gameObject;
                    _spriteBatch.Draw(_blockTexture, collidableObject.HitBox, Color.Green * 0.5f);
                }
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
