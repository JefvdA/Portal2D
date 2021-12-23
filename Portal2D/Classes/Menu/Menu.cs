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
        private Texture2D exitButton;
        public Vector2 position;
        private MouseState mouseState;
        public Menu(Texture2D Background, Texture2D Level1)
        {
            this.background = Background;
            this.Level1 = Level1;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            this.position = new Vector2(GameManager.ScreenWidth / 2 -201, GameManager.ScreenHeight / 2 -201);
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed) 
            {
                MouseClicked(mouseState.X, mouseState.Y);
                
            }
            spriteBatch.Draw(background, new Vector2(0, 0), Color.Gray * 0.2f);
            spriteBatch.Draw(Level1, position, Color.White * 1f);
        }
        void MouseClicked(int x, int y)
        {
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);
            Rectangle startButtonRect = new Rectangle((int)position.X,(int)position.Y, 100, 20);
            //Rectangle exitButtonRect = new Rectangle((int)exitButtonPosition.X,(int)exitButtonPosition.Y, 100, 20);
            if (mouseClickRect.Intersects(startButtonRect)) 
            {
                GameManager._gameState = GameState.Playing;
            }
            //else if (mouseClickRect.Intersects(exitButtonRect)) 
            //{
            //    Exit();
            //}
        }
    }
}
