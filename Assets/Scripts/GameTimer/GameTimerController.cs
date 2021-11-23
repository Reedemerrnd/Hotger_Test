using UnityEngine;

namespace Game.GameTimer
{
    internal sealed class GameTimerController : BaseController, IDoUpdate
    {
        private float _currentGameTime;
        private float _lastSpeedIncreaseTime;
        private bool _isEnabled;

        public GameTimerController(GameModel gameModel) : base(gameModel)
        {
            _currentGameTime = 0f;
            _lastSpeedIncreaseTime = gameModel.SpeedIncreaseDelay;
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
            _currentGameTime += Time.deltaTime;
            if (_currentGameTime >= _lastSpeedIncreaseTime)
            {
                _gameModel.VerticalSpeed *= _gameModel.SpeedIncreaseRate;
            }
        }

        protected override void OnGameOver()
        {
            _isEnabled = false;
            // Log stats
            Debug.Log(_currentGameTime);
        }

        protected override void OnGameStarted()
        {
            _currentGameTime = 0f;
            _isEnabled = true;
        }
    }
}
