using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Portal2D.Interfaces
{
    public interface IInputReader
    {
        public int GetHorizontal();

        public bool IsKeyPressed(Keys key);
    }
}
