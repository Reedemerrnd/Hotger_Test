using UnityEngine;

namespace Game.GameTimer
{
    internal sealed class GameTimerController : BaseController, IDoUpdate
    {
        private float _lastSpeedIncreaseTime;
        private bool _isEnabled;

        public GameTimerController(GameModel gameModel) : base(gameModel)
        {
            gameModel.CurrentRunTime = 0f;
            _lastSpeedIncreaseTime = 0f;
        }

        public void DoUpdate()
        {
            if (_isEnabled)
            {
                CountTimer();
            }
        }

        private void CountTimer()
        {
            var currentTime = _gameModel.CurrentRunTime;
            currentTime += Time.deltaTime;
            if (currentTime >= _lastSpeedIncreaseTime + _gameModel.SpeedIncreaseDelay)
            {
                _gameModel.VerticalSpeed *= _gameModel.SpeedIncreaseRate;
                _lastSpeedIncreaseTime = currentTime;
            }
            _gameModel.CurrentRunTime = currentTime;
        }

        protected override void OnGameOver()
        {
            _isEnabled = false;

        }

        protected override void OnGameStarted()
        {
            _gameModel.CurrentRunTime = 0f;
            _isEnabled = true;
        }
    }
}
