using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Interfaces;

namespace Portal2D.Classes.Main
{
    internal class Block : IGameObject, ICollidable
    {
        public Texture2D Texture { get; set; }
        public Color DrawColor { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public int Scale { get; set; }

        public Vector2 Position { get; set; }
        public Rectangle HitBox { get; set ; }
        public bool IsTrigger { get; set; }

        public Block(Texture2D texture, Color color, int scale, Vector2 position, bool isTrigger)
        {
            Texture = texture;
            Scale = scale;
            Position = position;
            DrawColor = color;
            IsTrigger = isTrigger;

            SourceRectangle = new Rectangle((int)Position.X, (int)Position.Y, 10 * Scale, 10 * Scale);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 10 * Scale, 10 * Scale);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, SourceRectangle, DrawColor);
        }

        public void Update(GameTime gameTime) { }
    }
}
