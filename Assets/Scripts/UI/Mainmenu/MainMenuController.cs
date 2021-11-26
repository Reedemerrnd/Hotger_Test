namespace BallGame.UI
{
    internal sealed class MainMenuController : BaseController
    {
        private readonly GameModel _gameModel;

        private MainMenuUIView _mainMenuUIView;

        public MainMenuController(GameModel gameModel, IUIFactory uIFactory)
        {
            _gameModel = gameModel;

            _mainMenuUIView = uIFactory.CreateMainMenu();
            AddDisablable(_mainMenuUIView);
        }

        protected override void OnEnable() => _mainMenuUIView.OnGameStart += HandleGameStart;
        protected override void OnDisable() => _mainMenuUIView.OnGameStart -= HandleGameStart;
        private void HandleGameStart(GameDifficulty difficulty)
        {
            _gameModel.Reset(difficulty);
            _gameModel.SetState(GameState.Game);
        }
    }
}
