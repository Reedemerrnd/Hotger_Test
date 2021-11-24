using System;

namespace Game
{
    internal abstract class BaseController : IDisposable
    {
        protected readonly GameModel _gameModel;

        public BaseController(GameModel gameModel)
        {
            _gameModel = gameModel;
            _gameModel.State.SubscribeOnChange(GameStateHandler);
        }
        protected virtual void OnGameOver() { }
        protected virtual void OnGameStarted() { }
        protected virtual void OnMenuOpen() { }
        protected virtual void OnDefault() { }


        private void GameStateHandler(GameState state)
        {
            switch (state)
            {
                case GameState.None:
                    OnDefault();
                    break;
                case GameState.MainMenu:
                    OnMenuOpen();
                    break;
                case GameState.Game:
                    OnGameStarted();
                    break;
                case GameState.GameOver:
                    OnGameOver();
                    break;
                default:
                    OnDefault();
                    break;
            }
        }

        public virtual void Dispose() => _gameModel.State.UnSubscribeOnChange(GameStateHandler);
    }
}
