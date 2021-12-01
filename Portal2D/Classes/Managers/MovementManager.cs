using Microsoft.Xna.Framework;
using Portal2D.Interfaces;

namespace Portal2D.Classes.Managers
{
    static class MovementManager
    {
        public static void Move(IMovable moveable)
        {
            var direction = moveable.InputReader.ReadInput();

            var distance = direction * new Vector2(moveable.Speed, 1);
            var futurePosition = moveable.Position + distance;

            if (futurePosition.X < (800 - 256) && futurePosition.X > 0)
                moveable.Position = futurePosition;
        }

        public static Vector2 PredictMove(IMovable moveable)
        {
            var direction = moveable.InputReader.ReadInput();

            var distance = direction * new Vector2(moveable.Speed, 1);
            var futurePosition = moveable.Position + distance;

            return futurePosition;
        }

    }
}
