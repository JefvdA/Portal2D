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
        private GameOverScreen gameOverScreen;

        // Variables for textures
        private Texture2D _spriteSheet;
        private Texture2D _background;
        private Texture2D _heroRunningTexture;
        private Texture2D _heroIdleTexture;
        private Texture2D _blockTexture;
        private Texture2D _level1;
        private Texture2D _exit;
        private Texture2D _enemyTexture;

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
            level1 = new Level(_background, _spriteSheet, _heroRunningTexture, _heroIdleTexture, _enemyTexture);
            currentLevel = level1;
            menu = new Menu(_background, _level1, _exit);
            gameOverScreen = new GameOverScreen(_exit);
            GameManager.OnStart();

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
            _heroRunningTexture = Content.Load<Texture2D>("Character_run");
            _heroIdleTexture = Content.Load<Texture2D>("Cyborg_idle");
            _background = Content.Load<Texture2D>("Background");
            _spriteSheet = Content.Load<Texture2D>("Spritesheet");
            _level1 = Content.Load<Texture2D>("Level1");
            _exit = Content.Load<Texture2D>("Exit");
            _enemyTexture = Content.Load<Texture2D>("CharacterSheet");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Back))
                Exit();
            if(GameManager._gameState == GameState.Playing)
                currentLevel.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameManager.CheckGameState();
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, samplerState: SamplerState.PointClamp);
            switch (GameManager._gameState)
            {
                case GameState.Playing:
                    this.IsMouseVisible = false;
                    currentLevel.Draw(_spriteBatch);
                    foreach (var gameObject in currentLevel.GameObjects)
                    {
                        if (gameObject is ICollidable && SHOW_HITBOXES)
                        {
                            ICollidable collidableObject = (ICollidable)gameObject;
                            _spriteBatch.Draw(_blockTexture, collidableObject.HitBox, Color.Green * 0.5f);
                        }
                    }
                    break;
                case GameState.MainMenu:
                    this.IsMouseVisible = true;
                    menu.Draw(_spriteBatch);
                    break;
                case GameState.Paused:
                    this.IsMouseVisible = true;
                    menu.Draw(_spriteBatch);
                    break;
                case GameState.Exit:
                    Exit();
                    break;
                case GameState.GameOver:
                    this.IsMouseVisible = true;
                    GraphicsDevice.Clear(Color.Blue);
                    gameOverScreen.Draw(_spriteBatch);
                    break;
                case GameState.GameWon:
                    break;
                default:
                    break;
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
