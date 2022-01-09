using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Portal2D.Interfaces;

namespace Portal2D.Classes.Enemies
{
    class AdvancedEnemy : Enemy
    {
        private IGameObject target;

        public AdvancedEnemy(Texture2D _texture, Vector2 _position, IGameObject _target) : base(_texture, _position)
        {
            direction = 0f;
            Speed = 2.5f;

            target = _target;
        }

        public override void Move()
        {
            Vector2 futurePosition = CalculateFuturePosition();

            Position = futurePosition;
        }
        public override Vector2 CalculateFuturePosition()
        {
            Vector2 targetPos = target.Position;

            var distance = targetPos - Position;
            if (distance.X > 0)
                direction = 1f;
            else if (distance.X < 0)
                direction = -1f;
            else
                direction = 0f;

            return base.CalculateFuturePosition();
        }
    }
}
