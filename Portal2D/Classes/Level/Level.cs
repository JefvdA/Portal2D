using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Portal2D.Classes.Level
{
    public class Level
    {
        private Texture2D backGround;

        public Level(Texture2D backGround)
        {
            this.backGround = backGround;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, new Vector2(0, 0), Color.White);
        }
    }
}
