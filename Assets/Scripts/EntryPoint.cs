using BallGame.Utils.ResourceLoad;
using UnityEngine;

namespace BallGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private UpdateManager _updateManager;

        private void Awake()
        {
            var gameModel = new GameModel(_gameSettings);

            var mainController = new MainController(gameModel, _updateManager);

            gameModel.SetState(_gameSettings.InitialState);
        }
    }
}
