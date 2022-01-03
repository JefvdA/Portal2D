using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.Menu
{
    class GameOverScreen
    {
        private Texture2D gameOverTexture;

        public GameOverScreen(Texture2D _gameOverTexture)
        {
            gameOverTexture = _gameOverTexture;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gameOverTexture, Vector2.Zero, Color.White);
        }
    }
}
