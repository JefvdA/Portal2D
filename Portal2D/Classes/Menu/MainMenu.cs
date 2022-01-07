using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Portal2D.Classes.Managers;
using Portal2D.Implementations;

namespace Portal2D.Classes.Menu
{
    class MainMenu
    {
        private Texture2D background;
        private Texture2D Level1;
        private Texture2D Level2;
        private Texture2D Exit;
        private Vector2 Level1position;
        private Vector2 Level2position;
        private Vector2 Exitposition;
        public MainMenu(Texture2D Background, Texture2D Level1,Texture2D Level2, Texture2D Exit)
        {
            this.background = Background;
            this.Level1 = Level1;
            this.Level2 = Level2;
            this.Exit = Exit;
            this.Level1position = new Vector2(560 , 200);
            this.Level2position = new Vector2(560, 500);
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
            spriteBatch.Draw(Level1, Level1position, Color.White);
            spriteBatch.Draw(Level2, Level2position, Color.White);
            spriteBatch.Draw(Exit, Exitposition, Color.White);
        }
        void MouseClicked(int x, int y)
        {
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);
            Rectangle level1ButtonRect = new Rectangle((int)Level1position.X,(int)Level1position.Y, 800, 200);
            Rectangle level2ButtonRect = new Rectangle((int)Level2position.X, (int)Level2position.Y, 800, 200);
            Rectangle exitButtonRect = new Rectangle((int)Exitposition.X, (int)Exitposition.Y, 800, 200);
            if (mouseClickRect.Intersects(level1ButtonRect))
            {
                GameManager._gameState = GameState.Playing;
            }
            else if (mouseClickRect.Intersects(level2ButtonRect))
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
