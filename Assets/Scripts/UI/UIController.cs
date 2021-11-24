using Game.ResourcesLoader;
using Game.Statistic;
using Game.Utils;

namespace Game.UI
{
    internal sealed class UIController : BaseController, IDoUpdate
    {
        private readonly ILoadResources _resourceLoader;
        private readonly IReadOnlyStatistics _gameStats;
        private InGameUIView _inGameUI;
        private MainMenuUIView _mainMenu;
        private GameOverUIView _gameOverMenu;


        public UIController(GameModel gameModel, ILoadResources resourceLoader, IReadOnlyStatistics gameStats) : base(gameModel)
        {
            _resourceLoader = resourceLoader;
            _gameStats = gameStats;
        }


        public void DoUpdate()
        {
            if (_gameModel.State.Value == GameState.Game)
            {
                _gameModel.UpButtonHold = _inGameUI.ButtonHold; 
            }
        }

        protected override void OnMenuOpen()
        {
            DisableUIs();
            LoadUI<MainMenuUIView>(ref _mainMenu, UIType.MainMenu);
            _mainMenu.OnGameStart += HandleGameStart;
        }

        private void HandleGameStart(GameDifficulty difficulty)
        {
            _gameModel.Reset(difficulty);
            _gameModel.State.Value = GameState.Game;
        }

        protected override void OnGameStarted()
        {
            DisableUIs();
            LoadUI<InGameUIView>(ref _inGameUI, UIType.InGame);
        }


        protected override void OnGameOver()
        {
            DisableUIs();
            LoadUI<GameOverUIView>(ref _gameOverMenu, UIType.GameOverMenu);
            _gameOverMenu.Init(HandleRestart, HandleSetDifficulty);
            _gameOverMenu.DisplayLength(_gameModel.CurrentRunTime.SecondsToTimeString());
            var tryCount = _gameStats.TotalTryCount + 1;
            _gameOverMenu.DisplayTryCount(tryCount.ToString());

        }

        private void HandleRestart()
        {
            _gameModel.ResetSameDifficulty();
            _gameModel.State.Value = GameState.Game;
        }

        private void HandleSetDifficulty() => _gameModel.State.Value = GameState.MainMenu;

        private void LoadUI<T>(ref T uiView, UIType uIType) where T : BaseUIView
        {
            if(uiView == null)
            {
                uiView = _resourceLoader.GetUIView(uIType) as T;
            }
            else
            {
                uiView.Enable();
            }
        }

        private void DisableUIs()
        {
            _inGameUI?.Disable();
            _mainMenu?.Disable();
            _gameOverMenu?.Disable();
        }
    }
}
