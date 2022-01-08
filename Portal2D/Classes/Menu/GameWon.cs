using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Portal2D.Classes.Managers;
using Portal2D.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.Menu
{
    class GameWon
    {
        private Texture2D exitTexture;
        private Texture2D background;
        private Texture2D mainMenuTexture;
        private Vector2 exitPosition;
        private Vector2 mainMenuPosition;

        public GameWon(Texture2D _background, Texture2D _mainmenuTexture, Texture2D _exitTexture)
        {
            exitTexture = _exitTexture;
            mainMenuTexture = _mainmenuTexture;
            background = _background;
            exitPosition = new Vector2(560, 800);
            mainMenuPosition = new Vector2(560, 500);
        }

        public void Update()
        {
            MouseState mouseState = MouseReader.GetState();
            if (MouseReader.leftClicked())
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Update();
            spriteBatch.Draw(background, Vector2.Zero, Color.Gray);
            spriteBatch.Draw(mainMenuTexture, mainMenuPosition, Color.White);
            spriteBatch.Draw(exitTexture, exitPosition, Color.White);
            spriteBatch.DrawString(Game1._score, "LEVEL COMPLETED", new Vector2(50, 100), Color.Black);
        }
        void MouseClicked(int x, int y)
        {
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);
            Rectangle mainMenuButtonRect = new Rectangle((int)mainMenuPosition.X, (int)mainMenuPosition.Y, 800, 200);
            Rectangle exitButtonRect = new Rectangle((int)exitPosition.X, (int)exitPosition.Y, 800, 200);
            if (mouseClickRect.Intersects(mainMenuButtonRect))
            {
                Game1.currentLevel.reset();
                GameManager._gameState = GameState.MainMenu;
            }
            if (mouseClickRect.Intersects(exitButtonRect))
            {
                GameManager._gameState = GameState.Exit;
            }
        }
    }
}
