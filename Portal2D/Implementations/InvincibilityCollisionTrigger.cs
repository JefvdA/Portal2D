using Microsoft.Xna.Framework;
using Portal2D.Classes.PickUp;
using Portal2D.Interfaces;

namespace Portal2D.Implementations
{
    class InvincibilityCollisionTrigger : PickUpAble
    {
        public InvincibilityCollisionTrigger(PickUps _pickUp) : base(_pickUp) { }
        public override void OnTrigger()
        {
            if (!pickUp.pickedUp)
            {
                Game1.currentLevel.vulnerable = false;
                pickUp.pickedUp = true;
                pickUp.HitBox = new Rectangle();
            }
        }
    }
}
