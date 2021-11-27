using BallGame.Game.UI;
using BallGame.UI;

namespace BallGame
{
    internal interface IUIFactory
    {
        MainMenuUIView CreateMainMenu();
        GameOverUIView CreateGameOverMenu();
        InGameUIView CreateInGameUI();
    }
}
