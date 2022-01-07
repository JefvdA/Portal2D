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
    class PausedMenu
    {
        private Texture2D background;
        private Texture2D Resume;
        private Texture2D mainMenu;
        private Texture2D Exit;
        private Vector2 Resumeposition;
        private Vector2 mainMenuPosition;
        private Vector2 Exitposition;
        public PausedMenu(Texture2D Background, Texture2D Resume,Texture2D mainMenu, Texture2D Exit)
        {
            this.background = Background;
            this.Resume = Resume;
            this.mainMenu = mainMenu;
            this.Exit = Exit;
            this.Resumeposition = new Vector2(560, 200);
            this.mainMenuPosition = new Vector2(560, 500);
            this.Exitposition = new Vector2(560, 800);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            MouseState mouseState = MouseReader.GetState();
            if (MouseReader.leftClicked())
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }
            spriteBatch.Draw(background, new Vector2(0, 0), Color.Gray);
            spriteBatch.Draw(mainMenu, mainMenuPosition, Color.White);
            spriteBatch.Draw(Resume, Resumeposition, Color.White);
            spriteBatch.Draw(Exit, Exitposition, Color.White);
        }
        void MouseClicked(int x, int y)
        {
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);
            Rectangle resumeButtonRect = new Rectangle((int)Resumeposition.X, (int)Resumeposition.Y, 800, 200);
            Rectangle mainMenuButtonRect = new Rectangle((int)mainMenuPosition.X, (int)mainMenuPosition.Y, 800, 200);
            Rectangle exitButtonRect = new Rectangle((int)Exitposition.X, (int)Exitposition.Y, 800, 200);
            if (mouseClickRect.Intersects(resumeButtonRect))
            {
                GameManager._gameState = GameState.Playing;
            }
            else if (mouseClickRect.Intersects(mainMenuButtonRect))
            {
                GameManager._gameState = GameState.MainMenu;
            }
            else if (mouseClickRect.Intersects(exitButtonRect))
            {
                GameManager._gameState = GameState.Exit;
            }
        }
    }
}
