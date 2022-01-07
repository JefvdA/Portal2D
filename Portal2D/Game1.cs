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
using System;

namespace Portal2D
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const bool SHOW_HITBOXES = true;

        // Reference to Level
        public static Level currentLevel;
        public static Level level1;
        public static Level level2;

        //Reference to Menu
        private MainMenu mainMenu;
        private PausedMenu pausedMenu;
        private GameOverScreen gameOverScreen;

        // Variables for textures
        private Texture2D _spriteSheet;
        private Texture2D _background;
        private Texture2D _heroRunningTexture;
        private Texture2D _heroIdleTexture;
        private Texture2D _blockTexture;
        private Texture2D _level1;
        private Texture2D _level2;
        private Texture2D _exit;
        private Texture2D _play;
        private Texture2D _playagain;
        private Texture2D _mainmenu;
        private Texture2D _basicEnemyTexture;
        private Texture2D _advancedEnemyTexture;
        private Texture2D _background2;
        private Texture2D _spikes;
        public static Texture2D _heart;

        public static SpriteFont _score;

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
            level1 = new Level(_background, _spriteSheet, _heroRunningTexture, _heroIdleTexture, _basicEnemyTexture, _advancedEnemyTexture, _spikes);
            level2 = new Level(_background2, _spriteSheet, _heroRunningTexture, _heroIdleTexture, _basicEnemyTexture, _advancedEnemyTexture, _spikes);
            currentLevel = level1;
            mainMenu = new MainMenu(_background, _level1, _level2, _exit);
            pausedMenu = new PausedMenu(_background, _play, _mainmenu, _exit);
            gameOverScreen = new GameOverScreen(_background,_mainmenu,_playagain, _exit);
            GameManager.OnStart();

            //uncomment for fullscreen
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.ToggleFullScreen();
            _graphics.ApplyChanges();

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
            _background2 = Content.Load<Texture2D>("TestBackground");
            _spriteSheet = Content.Load<Texture2D>("Spritesheet");
            _level1 = Content.Load<Texture2D>("Level 1");
            _level2 = Content.Load<Texture2D>("Level 2");
            _exit = Content.Load<Texture2D>("exit");
            _play = Content.Load<Texture2D>("Play");
            _playagain = Content.Load<Texture2D>("Playagain");
            _mainmenu = Content.Load<Texture2D>("mainmenu");
            _basicEnemyTexture = Content.Load<Texture2D>("Biker_run");
            _advancedEnemyTexture = Content.Load<Texture2D>("Punk_run");
            _spikes = Content.Load<Texture2D>("Spikes");
            _heart = Content.Load<Texture2D>("Heart");

            _score = Content.Load<SpriteFont>("score");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Back))
                Exit();
            GameManager.CheckGameState();
            if (GameManager._gameState == GameState.Playing)
                currentLevel.Update(gameTime);
            // This Doesnt work, needs fixing
            //
            //switch (GameManager._gameState)
            //{
            //    case GameState.Playing:
            //        currentLevel.Update(gameTime);
            //        break;
            //    case GameState.MainMenu:
            //        mainMenu.Update();
            //        break;
            //    case GameState.Paused:
            //        pausedMenu.Update();
            //        break;
            //    case GameState.Exit:
            //        Exit();
            //        break;
            //    case GameState.GameOver:
            //        gameOverScreen.Update();
            //        break;
            //    case GameState.GameWon:
            //        break;
            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
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
                    mainMenu.Draw(_spriteBatch);
                    break;
                case GameState.Paused:
                    this.IsMouseVisible = true;
                    pausedMenu.Draw(_spriteBatch);
                    break;
                case GameState.Exit:
                    Exit();
                    break;
                case GameState.GameOver:
                    this.IsMouseVisible = true;
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
