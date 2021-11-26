using BallGame.Game;
using BallGame.GameOver;
using BallGame.Statistic;
using BallGame.UI;
using BallGame.Utils.ResourceLoad;
using BallGame.Utils.Screen;

namespace BallGame
{
    internal sealed class MainController : BaseController
    {
        private readonly GameModel _gameModel;
        private readonly UpdateManager _updateManager;
        private readonly ScreenBounds _screenBounds;
        private GameController _gameController;
        private ResourceLoader _resourceLoader;
        private Factory _factory;
        private GameStatictics _statisticFile;
        private GameOverController _gameOverController;
        private MainMenuController _mainMenuController;

        public MainController(GameModel gameModel, UpdateManager updateManager)
        {
            _gameModel = gameModel;
            _updateManager = updateManager;

            _screenBounds = new ScreenBounds();
            _resourceLoader = new ResourceLoader();
            _factory = new Factory(_resourceLoader);

            _statisticFile = _resourceLoader.LoadStatsFile();

            _gameModel.State.SubscribeOnChange(HandleGameState);
        }

        private void HandleGameState(GameState gameState)
        {
            DisableControllers();
            switch (gameState)
            {
                case GameState.MainMenu:
                    EnableMainMenuController();
                    break;
                case GameState.Game:
                    EnableGameController();
                    break;
                case GameState.GameOver:
                    EnableGameOverController();
                    break;
                default:
                    break;
            }
        }

        private void EnableMainMenuController()
        {
            if (_mainMenuController == null)
            {
                _mainMenuController = new MainMenuController(_gameModel, _factory);
                AddDisablable(_mainMenuController);
            }
            _mainMenuController.Enable();
        }

        private void EnableGameController()
        {
            if (_gameController == null)
            {
                _gameController = new GameController(_gameModel, _factory, _updateManager, _screenBounds);
                AddDisablable(_gameController); 
            }
            _gameController.Enable();
        }

        private void EnableGameOverController()
        {
            if (_gameOverController == null)
            {
                _gameOverController = new GameOverController(_gameModel, _factory, _statisticFile);
                AddDisablable(_gameOverController); 
            }
            _gameOverController.Enable();
        }

        private void DisableControllers()
        {
            _mainMenuController?.Disable();
            _gameController?.Disable();
            _gameOverController?.Disable();
        }
    }
}
