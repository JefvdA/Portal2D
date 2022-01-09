using Portal2D.Interfaces;


namespace Portal2D.Implementations
{
    class EnemyCollsionTrigger : ICollisionTrigger
    {
        public void OnTrigger()
        {
            Game1.currentLevel.LoseLive();
        }
    }
}
