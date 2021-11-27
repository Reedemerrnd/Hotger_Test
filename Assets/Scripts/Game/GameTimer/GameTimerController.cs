using UnityEngine;

namespace BallGame.Game.Times
{
    internal sealed class GameTimerController : BaseController
    {
        private float _lastSpeedIncreaseTime;
        private readonly GameModel _gameModel;
        private readonly UpdateManager _updateManager;


        public GameTimerController(GameModel gameModel, UpdateManager updateManager)
        {
            _gameModel = gameModel;
            _updateManager = updateManager;

            OnEnable();
        }


        private void ResetTimers()
        {
            _gameModel.CurrentRunTime = 0f;
            _lastSpeedIncreaseTime = 0f;
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


        protected override void OnEnable()
        {
            ResetTimers();
            _updateManager.SubscribeOnUpdate(CountTimer);
        }

        protected override void OnDisable() => _updateManager.UnSubscribeOnUpdate(CountTimer);
    }
}
