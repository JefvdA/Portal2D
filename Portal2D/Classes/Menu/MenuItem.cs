using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.Menu
{
    class MenuItem
    {
        public String text;
        public Vector2 position;
        public float size;
        public SpriteFont spriteFont;

        public MenuItem(String text, Vector2 position, float size) 
        {
            this.text = text;
            this.position = position;
            this.size = size;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, text, position, Color.Black);
        }
    }
}
