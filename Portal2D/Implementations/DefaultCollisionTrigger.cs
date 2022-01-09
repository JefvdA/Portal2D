using Portal2D.Interfaces;
using System.Diagnostics;

namespace Portal2D.Implementations
{
    internal class DefaultCollisionTrigger : ICollisionTrigger
    {
        public void OnTrigger() 
        {
            Debug.WriteLine("Trigger enter on : " + this);
        }
    }
}
    