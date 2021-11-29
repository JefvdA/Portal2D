using Portal2D.Interfaces;

namespace Portal2D.Classes
{
    static class MovementManager
    {
        public static void Move(IMovable moveable)
        {
            var direction = moveable.InputReader.ReadInput();

            var distance = direction * moveable.Speed;
            var futurePosition = moveable.Position + distance;
            
            if(futurePosition.X < (800-256) && futurePosition.X > 0) 
                moveable.Position = futurePosition;
        }

    }
}
