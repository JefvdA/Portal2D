using Microsoft.Xna.Framework;
using Portal2D.Classes.PickUp;

namespace Portal2D.Implementations
{
    class PickUpCollisionTrigger : PickUpAble
    {

        public PickUpCollisionTrigger(PickUps _pickUp) : base(_pickUp)
        {

        }
        public override void OnTrigger()
        {
            if (!pickUp.pickedUp)
            {
                Game1.currentLevel.score++;
                pickUp.pickedUp = true;
                pickUp.HitBox = new Rectangle();
            }
        }
    }
}
