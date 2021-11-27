using BallGame.Utils.Screen;

namespace BallGame.Game.Level
{
    internal sealed class LevelController : BaseController
    {
        private readonly GameModel _gameModel;
        private readonly ScreenBounds _screenBounds;
        private readonly ILevelView _levelView;
        private readonly UpdateManager _updateManager;


        public LevelController(GameModel gameModel, ScreenBounds screenBounds, ILevelView levelView, UpdateManager updateManager)
        {
            _gameModel = gameModel;
            _screenBounds = screenBounds;
            _levelView = levelView;
            _updateManager = updateManager;

            var xOffsets = CalculateOffset();
            _levelView.Construct(xOffsets.xLeft, xOffsets.xRight);
        }


        private (float xLeft, float xRight) CalculateOffset()
        {
            var halfWidth = _screenBounds.Width / 2f;
            float xLeft = _screenBounds.BottomLeft.x - halfWidth;
            float xRight = _screenBounds.TopRight.x + halfWidth;
            return (xLeft, xRight);
        }


        private void MoveLevel() => _levelView?.Move(_gameModel.HorizontalSpeed);


        protected override void OnDisable() => _updateManager.UnSubscribeOnUpdate(MoveLevel);
        protected override void OnEnable() => _updateManager.SubscribeOnUpdate(MoveLevel);
    }
}
