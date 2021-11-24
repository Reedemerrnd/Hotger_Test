using Game.ResourcesLoader;

namespace Game.Ball
{
    internal sealed class BallController : BaseController, IDoUpdate
    {
        private readonly ILoadResources _resourceLoader;
        private IBallView _ballView;
        private bool _isEnabled;


        public BallController(GameModel gameModel, ILoadResources resourceLoader) : base(gameModel)
        {
            _resourceLoader = resourceLoader;
        }


        public void DoUpdate()
        {
            if (_gameModel.State.Value == GameState.Game)
            {
                HandleMovement(); 
            }
        }

        private void HandleMovement()
        {
                var speed = _gameModel.VerticalSpeed;
                var resultSpeed = _gameModel.UpButtonHold ? speed * -1f : speed;

                _ballView.Move(resultSpeed); 
        }

        protected override void OnGameStarted()
        {
            LoadBall();
        }

        private void Disable()
        {
            _ballView.OnCollision -= CollisionHandler;
            _ballView.Disable();
        }

        private void LoadBall()
        {
            if (_ballView == null)
            {
                _ballView = _resourceLoader.GetBallView(_gameModel.BallSpawnPosition);
            }
            else
            {
                _ballView.Enable();
                _ballView.SetPosition(_gameModel.BallSpawnPosition);
            }
            _ballView.OnCollision += CollisionHandler;
        }
        private void CollisionHandler()
        {
            _gameModel.State.Value = GameState.GameOver;
            Disable();
        }
    }
}
