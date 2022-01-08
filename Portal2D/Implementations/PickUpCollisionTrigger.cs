using Microsoft.Xna.Framework;
using Portal2D.Classes.PickUp;
using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Implementations
{
    class PickUpCollisionTrigger : ICollisionTrigger
    {
        private PickUps pickUp;
        public PickUpCollisionTrigger(PickUps _pickUp)
        {
            pickUp = _pickUp;
        }
        public void OnTrigger()
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
