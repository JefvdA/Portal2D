using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Classes.Managers;

namespace Portal2D.Classes.Enemies
{
    class BasicEnemy : Enemy
    {
        private int minX;
        private int maxX;

        public BasicEnemy(Texture2D _texture, Vector2 _position, int _minX, int _maxX) : base(_texture, _position)
        {
            direction = 1f;
            Speed = 2.5f;

            minX = _minX;
            maxX = _maxX;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!CanMove)
                direction *= -1;
        }

        public override void Move()
        {
            Vector2 futurePosition = CalculateFuturePosition();

            if (futurePosition.X >= maxX || futurePosition.X <= minX      ||      futurePosition.X >= (GameManager.ScreenWidth-128) || futurePosition.X <= 0)
            {
                direction *= -1;
                futurePosition = CalculateFuturePosition();
            }

            Position = futurePosition;
        }
    }
}
