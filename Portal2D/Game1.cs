using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Portal2D.Classes.Main;
using Portal2D.Classes.Player;
using Portal2D.Interfaces;

namespace Portal2D
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Color backGroundColor = Color.CornflowerBlue;

        private Texture2D _heroTexture;
        private IInputReader _inputReader;

        private Hero hero;

        // Variables for block
        private Texture2D _blockTexture;

        private Block block1;
        private Block block2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            hero = new Hero(_heroTexture, _inputReader);

            block1 = new Block(_blockTexture, Color.Green, 5, new Vector2(125, 125));
            block2 = new Block(_blockTexture, Color.Red, 5, new Vector2(150, 150));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _blockTexture = new Texture2D(GraphicsDevice, 1, 1);
            _blockTexture.SetData(new[] { Color.White });

            _heroTexture = Content.Load<Texture2D>("CharacterSheet");
            _inputReader = new KeyboardReader();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            hero.Update(gameTime);

            if (CollisionManager.CheckCollision(block1, hero))
                backGroundColor = Color.Black;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backGroundColor);
            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);

            block1.Draw(_spriteBatch);
            block2.Draw(_spriteBatch);

            _spriteBatch.Draw(_blockTexture, hero.HitBox, Color.Red * 0.5f);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
