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

        public override void Move()
        {
            float futureX = Position.X + direction * Speed;

            if (futureX >= maxX || futureX <= minX      ||      futureX >= (GameManager.ScreenWidth-128) || futureX <= 0)
                direction *= -1;

            Position += new Vector2(direction * Speed, 0);
        }
    }
}
