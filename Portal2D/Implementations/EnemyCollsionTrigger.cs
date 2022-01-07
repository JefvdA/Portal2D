﻿using System;
using System.Collections.Generic;
using System.Text;
using Portal2D.Classes.Managers;
using Portal2D.Interfaces;


namespace Portal2D.Implementations
{
    class EnemyCollsionTrigger : ICollisionTrigger
    {
        public void OnTrigger()
        {
            GameManager._gameState = GameState.GameOver;
        }
    }
}