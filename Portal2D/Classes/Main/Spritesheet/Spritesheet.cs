using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace Portal2D.Classes.Main.Spritesheet
{
    internal class Spritesheet
    {
        private List<SpritesheetItem> items;

        public Spritesheet()
        {
            items = new List<SpritesheetItem>();
        }

        public void GetItemsFromProperties(int width, int height, int numberOfWidthItems, int numberOfHeightItems)
        {
            int widthOfItem = width / numberOfWidthItems;
            int heigthOfItem = height / numberOfHeightItems;

            for (int y = 0; y <= height - heigthOfItem; y += heigthOfItem)
            {
                for (int x = 0; x < width - widthOfItem; x += widthOfItem)
                {
                    items.Add(new SpritesheetItem(new Rectangle(x, y, widthOfItem, heigthOfItem)));
                }
            }
        }

        public Rectangle GetItem(int itemID)
        {
            var item = items[itemID];
            return item.SourceRectangle;
        }
    }
}
