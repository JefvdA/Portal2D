using Portal2D.Classes.PickUp;
using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal2D.Implementations
{
    class PickUpAble : ICollisionTrigger
    {
        protected PickUps pickUp;
        public PickUpAble(PickUps _pickUp) 
        {
            pickUp = _pickUp;
        }
        public virtual void OnTrigger()
        {
            
        }
    }
}
