using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Interfaces;

namespace Portal2D.Classes
{
    internal class Block : IGameObject
    {
        public Texture2D Texture { get; set; }
        public Color DrawColor { get; set; }
        public Rectangle Rect { get; set; }
        public int Scale { get; set; }

        public Vector2 Position { get; set; }

        public Block(Texture2D texture, Color color, int scale, Vector2 position)
        {
            Texture = texture;
            Scale = scale;
            Position = position;
            DrawColor = color;

            Rect = new Rectangle((int)Position.X, (int)Position.Y, 10 * scale, 10 * scale);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rect, DrawColor);
        }

        public void Update(GameTime gameTime) { }
    }
}
