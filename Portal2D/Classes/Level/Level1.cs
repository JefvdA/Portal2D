using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Classes.Level
{
    class Level1
    {
        private Texture2D backGround;
        private Vector2 position;

        public Level1() { }
        public Level1(Texture2D backGround) 
        {
            this.backGround = backGround;
            position = new Vector2(0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, position, Color.White);
        }
    }
}
