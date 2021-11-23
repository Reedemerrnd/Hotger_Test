using UnityEngine;

namespace Game.Ball
{
    internal sealed class BallController : BaseController, IDoUpdate
    {
        private readonly IPrefabContainer _prefabContainer;
        private IBallView _ballView;

        public BallController(GameModel gameModel, IPrefabContainer prefabContainer) : base(gameModel)
        {
            _prefabContainer = prefabContainer;
        }

        public void DoUpdate() => _ballView?.Move(_gameModel.VerticalSpeed);

        private void OnCollision() => _gameModel.State.Value = GameState.GameOver;

        protected override void OnGameStarted() => LoadBall();

        private void LoadBall()
        {
            if (_ballView == null)
            {
                var ball = UnityEngine.Object.Instantiate(_prefabContainer.BallPrefab, _prefabContainer.BallSpawnPosition, Quaternion.identity);
                _ballView = ball.GetComponent<IBallView>();
                _ballView.Construct(OnCollision);
            }

        }
    }
}
