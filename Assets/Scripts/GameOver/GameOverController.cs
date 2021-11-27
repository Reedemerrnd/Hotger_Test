using BallGame.Statistic;
using BallGame.UI;

namespace BallGame.GameOver
{
    internal sealed class GameOverController : BaseController
    {
        private readonly ILogger _logger;


        public GameOverController(GameModel gameModel, IUIFactory uIFactory, GameStatictics gameStatictics)
        {
            _logger = new ScriptableObjectLogger(gameStatictics);

            var gameOverUI = uIFactory.CreateGameOverMenu();
            AddDisablable(gameOverUI);

            var gameOverUIController = new GameOverUIController(gameModel, gameOverUI, gameStatictics);
            AddDisablable(gameOverUIController);
        }


        protected override void OnEnable()
        {
            _logger.LogTryCount();
        }
    }
}
