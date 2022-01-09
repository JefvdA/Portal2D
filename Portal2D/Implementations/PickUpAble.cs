using Portal2D.Classes.PickUp;
using Portal2D.Interfaces;

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
