using Microsoft.Xna.Framework;
using Portal2D.Classes.PickUp;
using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Implementations
{
    class ExtraHealthCollisionTrigger : PickUpAble, ICollisionTrigger
    {
        public ExtraHealthCollisionTrigger(PickUps _pickUp) : base(_pickUp) {}
        public override void OnTrigger()
        {
            if (!pickUp.pickedUp)
            {
                Game1.currentLevel.lives++;
                pickUp.pickedUp = true;
                pickUp.HitBox = new Rectangle();
            }
        }
    }
}
