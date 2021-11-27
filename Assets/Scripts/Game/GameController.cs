using BallGame.Game.Ball;
using BallGame.Game.Level;
using BallGame.Game.Times;
using BallGame.Game.UI;
using BallGame.Utils.Screen;

namespace BallGame.Game
{
    internal sealed class GameController : BaseController
    {
        public GameController(GameModel gameModel, Factory gameFactory, UpdateManager updateManager, ScreenBounds screenBounds)
        {
            var ballView = gameFactory.CreateBallView(gameModel.BallSpawnPosition);
            AddDisablable(ballView);

            var ballController = new BallController(gameModel, ballView, updateManager);
            AddDisablable(ballController);

            var levelView = gameFactory.CreateLevelView();
            AddDisablable(levelView);

            var levelController = new LevelController(gameModel, screenBounds, levelView, updateManager);
            AddDisablable(levelController);

            var gameTimeController = new GameTimerController(gameModel, updateManager);
            AddDisablable(gameTimeController);

            var inGameUI = gameFactory.CreateInGameUI();
            AddDisablable(inGameUI);

            var uiController = new InGameUIController(inGameUI, gameModel);
            AddDisablable(uiController);

            var obstaclePool = gameFactory.CreateObstaclePool();
            var obstacleController = new ObstacleController(obstaclePool, gameModel, levelView, screenBounds, updateManager);
            AddDisablable(obstacleController);
        }
    }
}
