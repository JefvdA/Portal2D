using Microsoft.Xna.Framework;
using Portal2D.Classes.Managers;
using Portal2D.Interfaces;

namespace Portal2D.Implementations
{
    internal class ChangeBGColorCollisionTrigger : ICollisionTrigger
    {
        private Color color;

        public ChangeBGColorCollisionTrigger(Color color)
        {
            this.color = color;
        }

        public void OnTrigger()
        {
            GameManager.backGroundColor = this.color;
        }
    }
}
