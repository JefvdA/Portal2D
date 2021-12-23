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
        private List<MenuItem> items;
        public MenuItem selected;
        private Vector2 position;
        public Menu(Texture2D Background) 
        {
            this.background = Background;
            MenuItem a = new MenuItem("test", new Vector2(10, 10), 5f);
            //items.Add(a);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background,new Vector2(0,0), Color.White * 0.8f);
            foreach (var item in items)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
