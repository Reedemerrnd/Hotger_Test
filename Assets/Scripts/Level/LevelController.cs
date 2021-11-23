using Game.Utils;

namespace Game.Level
{
    internal sealed class LevelController : BaseController, IDoUpdate
    {
        private readonly IPrefabContainer _prefabContainer;
        private readonly ScreenBounds _screenBounds;

        private ILevelView _levelView;


        public LevelController(GameModel gameModel, IPrefabContainer prefabContainer, ScreenBounds screenBounds) : base(gameModel)
        {
            _prefabContainer = prefabContainer;
            _screenBounds = screenBounds;
        }

        protected override void OnGameStarted()
        {
            LoadLevel();
        }
        private void LoadLevel()
        {
            if (_levelView == null)
            {
                var level = UnityEngine.Object.Instantiate(_prefabContainer.LevelPrefab);
                _levelView = level.GetComponent<ILevelView>();
                _levelView.Construct(_screenBounds);
            }

        }

        public void DoUpdate() => _levelView.Move(_gameModel.HorizontalSpeed);
    }
}
