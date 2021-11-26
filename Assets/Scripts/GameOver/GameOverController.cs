using BallGame.Statistic;
using BallGame.UI;

namespace BallGame.GameOver
{
    internal sealed class GameOverController : BaseController
    {
        private readonly GameModel _gameModel;
        private readonly ILogger _logger;

        public GameOverController(GameModel gameModel, IUIFactory uIFactory, GameStatictics gameStatictics)
        {
            _gameModel = gameModel;
            _logger = new ScriptableObjectLogger(gameStatictics);

            var gameOverUI = uIFactory.CreateGameOverMenu();
            AddDisablable(gameOverUI);

            var gameOverUIController = new GameOverUIController(_gameModel, gameOverUI, gameStatictics);
            AddDisablable(gameOverUIController);
        }

        protected override void OnEnable()
        {
            _logger.LogTryCount();
        }
    }
}
