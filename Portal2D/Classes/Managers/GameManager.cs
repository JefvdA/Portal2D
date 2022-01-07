using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Portal2D.Implementations;
using Portal2D.Interfaces;

namespace Portal2D.Classes.Managers
{
    static class GameManager
    {
        public static IInputReader inputreader { get; set; }
        public static GameState _gameState { get; set; }
        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }

        public static Color backGroundColor = Color.CornflowerBlue;
        public static int Gravity = 15;

        public static void OnStart()
        {
            inputreader = new KeyboardReader();
            _gameState = GameState.MainMenu;
        }
        public static void CheckGameState()
        {
            if (inputreader.IsKeyPressed(Keys.Escape) == true)
            {
                if (_gameState == GameState.Playing)
                    _gameState = GameState.Paused;
            }
        }
    }
    enum GameState
    {
        Playing, MainMenu,Paused, Exit, GameOver, GameWon
    }
}
