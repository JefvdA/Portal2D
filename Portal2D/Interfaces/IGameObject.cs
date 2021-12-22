using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Portal2D.Interfaces
{
    public interface IGameObject
    {
        public Vector2 Position { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
