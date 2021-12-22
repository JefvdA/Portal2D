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

        public Menu(Texture2D Background) 
        {
            this.background = Background;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0,0), Color.White);
        }
    }
}
