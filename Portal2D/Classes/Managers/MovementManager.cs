using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            distance.Y += 2;

            if (futurePosition.X < (800 - 256) && futurePosition.X > 0)
                moveable.Position += new Vector2(distance.X,0);
            if (futurePosition.Y < (230) && futurePosition.Y > 0)
                moveable.Position += new Vector2(0,distance.Y);
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
