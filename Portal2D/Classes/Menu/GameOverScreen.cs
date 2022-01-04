using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Portal2D.Classes.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.Menu
{
    class GameOverScreen
    {
        private Texture2D exitTexture;
        private Vector2 ExitPosition;
        private MouseState mouseState;

        public GameOverScreen(Texture2D _exitTexture)
        {
            exitTexture = _exitTexture;
            ExitPosition = Vector2.Zero;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }
            spriteBatch.Draw(exitTexture, Vector2.Zero, Color.White);
        }
        void MouseClicked(int x, int y)
        {
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);
            Rectangle exitButtonRect = new Rectangle((int)ExitPosition.X, (int)ExitPosition.Y, 512, 512);
            if (mouseClickRect.Intersects(exitButtonRect))
            {
                GameManager._gameState = GameState.Exit;
            }
        }
    }
}
