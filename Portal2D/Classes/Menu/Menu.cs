using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Portal2D.Classes.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.Menu
{
    class Menu
    {
        private Texture2D background;
        private Texture2D Level1;
        private Texture2D Exit;
        private Vector2 Level1position;
        private Vector2 Exitposition;
        private MouseState mouseState;
        public Menu(Texture2D Background, Texture2D Level1, Texture2D Exit)
        {
            this.background = Background;
            this.Level1 = Level1;
            this.Exit = Exit;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            this.Level1position = new Vector2(GameManager.ScreenWidth / 2 -201, GameManager.ScreenHeight / 2 -201);
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed) 
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }
            spriteBatch.Draw(background, new Vector2(0, 0), Color.Gray * 0.2f);
            spriteBatch.Draw(Level1, Level1position, Color.White * 1f);
            spriteBatch.Draw(Exit, Exitposition, Color.White * 1f);
        }
        void MouseClicked(int x, int y)
        {
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);
            Rectangle startButtonRect = new Rectangle((int)Level1position.X,(int)Level1position.Y, 403, 403);
            Rectangle exitButtonRect = new Rectangle((int)Exitposition.X,(int)Exitposition.Y, 512, 512);
            if (mouseClickRect.Intersects(startButtonRect)) 
            {
                GameManager._gameState = GameState.Playing;
            }
            else if (mouseClickRect.Intersects(exitButtonRect)) 
            {
                GameManager._gameState = GameState.Exit;
            }
        }
    }
}
