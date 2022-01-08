﻿using Microsoft.Xna.Framework;
using Portal2D.Classes.Managers;
using Portal2D.Classes.PickUp;
using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
