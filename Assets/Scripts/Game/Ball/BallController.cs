namespace BallGame.Game.Ball
{
    internal sealed class BallController : BaseController
    {
        private readonly GameModel _gameModel;
        private readonly IBallView _ballView;
        private readonly UpdateManager _updateManager;


        public BallController(GameModel gameModel, IBallView ballView, UpdateManager updateManager)
        {
            _gameModel = gameModel;
            _ballView = ballView;
            _updateManager = updateManager;
        }


        protected override void OnDisable()
        {
            _updateManager.UnSubscribeOnUpdate(HandleMovement);
            _ballView.OnCollision -= CollisionHandler;
        }

        protected override void OnEnable()
        {
            _ballView.SetPosition(_gameModel.BallSpawnPosition);
            _updateManager.SubscribeOnUpdate(HandleMovement);
            _ballView.OnCollision += CollisionHandler;
        }


        private void HandleMovement()
        {
            var speed = _gameModel.VerticalSpeed;
            var resultSpeed = _gameModel.UpButtonHold ? speed * -1f : speed;

            _ballView.Move(resultSpeed);
        }

        private void CollisionHandler()
        {
            _gameModel.SetState(GameState.GameOver);
        }
    }
}
