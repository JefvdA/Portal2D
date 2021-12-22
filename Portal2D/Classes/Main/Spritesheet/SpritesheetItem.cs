using Microsoft.Xna.Framework;

namespace Portal2D.Classes.Main.Spritesheet
{
    internal class SpritesheetItem
    {
        public Rectangle SourceRectangle { get; set; }

        public SpritesheetItem(Rectangle sourceRectangle)
        {
            SourceRectangle = sourceRectangle;
        }
    }
}
