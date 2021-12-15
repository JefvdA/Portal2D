using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.Menu
{
    class Menu
    {
        private Texture2D background;
        private Vector2 position;

        public Menu(Texture2D Background) 
        {
            this.background = Background;
            position = new Vector2(0, 0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, position, Color.White);
        }
    }
}
