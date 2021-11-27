using BallGame.Game.Ball;
using BallGame.Game.Level;
using BallGame.Game.Times;
using BallGame.Game.UI;
using BallGame.Utils.Screen;

namespace BallGame.Game
{
    internal sealed class GameController : BaseController
    {
        private readonly GameModel _gameModel;
        private readonly Factory _gameFactory;
        private BallView _ballView;

        public GameController(GameModel gameModel, Factory gameFactory, UpdateManager updateManager, ScreenBounds screenBounds)
        {
            _gameModel = gameModel;
            _gameFactory = gameFactory;
            _ballView = _gameFactory.CreateBallView(_gameModel.BallSpawnPosition);
            AddDisablable(_ballView);

            var ballController = new BallController(_gameModel, _ballView, updateManager);
            AddDisablable(ballController);

            var levelView = _gameFactory.CreateLevelView();
            AddDisablable(levelView);

            var levelController = new LevelController(_gameModel, screenBounds, levelView, updateManager);
            AddDisablable(levelController);

            var gameTimeController = new GameTimerController(_gameModel, updateManager);
            AddDisablable(gameTimeController);

            var inGameUI = _gameFactory.CreateInGameUI();
            AddDisablable(inGameUI);

            var uiController = new InGameUIController(inGameUI, _gameModel);
            AddDisablable(uiController);

            var obstaclePool = _gameFactory.CreateObstaclePool();
            var obstacleController = new ObstacleController(obstaclePool, gameModel, levelView, screenBounds, updateManager);
            AddDisablable(obstacleController);
        }
        


        protected override void OnEnable()
        {
            _ballView.SetPosition(_gameModel.BallSpawnPosition);
        }
    }
}
