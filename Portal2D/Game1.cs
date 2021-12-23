using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Portal2D.Classes.Main;
using Portal2D.Classes.Managers;
using Portal2D.Interfaces;
using Portal2D.Implementations;
using System.Collections.Generic;
using Portal2D.Classes.Level;
using Portal2D.Classes.Menu;

namespace Portal2D
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const bool SHOW_HITBOXES = true;

        // Reference to Level
        private Level currentLevel;
        private Level level1;

        //Reference to Menu
        private Menu menu;

        // Variables for textures
        private Texture2D _spriteSheet;
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

            level1 = new Level(_background, _spriteSheet, _heroTexture);
            currentLevel = level1;
            menu = new Menu(_background);
            GameManager.OnStart();

            currentLevel.AddGameObject(new Block(_blockTexture, Color.Black, 10, new Vector2(500, 950), false, new DefaultCollisionTrigger()));
            currentLevel.AddGameObject(new Block(_blockTexture, Color.Black, 10, new Vector2(700, 950), false, new DefaultCollisionTrigger()));

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
            _spriteSheet = Content.Load<Texture2D>("Spritesheet");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(GameManager._gameState == GameState.Playing)
                currentLevel.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameManager.CheckGameState();
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, samplerState: SamplerState.PointClamp);
            if (GameManager._gameState == GameState.InMenu) 
            {
                menu.Draw(_spriteBatch);
            }
            else
            {
                currentLevel.Draw(_spriteBatch);

                foreach (var gameObject in currentLevel.GameObjects)
                {
                    if (gameObject is ICollidable && SHOW_HITBOXES)
                    {
                        ICollidable collidableObject = (ICollidable)gameObject;
                        _spriteBatch.Draw(_blockTexture, collidableObject.HitBox, Color.Green * 0.5f);
                    }
                }
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
