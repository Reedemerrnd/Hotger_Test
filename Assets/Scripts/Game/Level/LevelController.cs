using Game.ResourcesLoader;
using Game.Utils;

namespace Game.Level
{
    internal sealed class LevelController : BaseController, IDoUpdate
    {
        private readonly ILoadResources _resourceLoader;
        private readonly ScreenBounds _screenBounds;

        private ILevelView _levelView;


        public LevelController(GameModel gameModel,ILoadResources resourceLoader, ScreenBounds screenBounds) : base(gameModel)
        {
            _resourceLoader = resourceLoader;
            _screenBounds = screenBounds;
        }
        
        
        public void DoUpdate() => _levelView?.Move(_gameModel.HorizontalSpeed);


        protected override void OnGameStarted()
        {
            LoadLevel();
        }

        private void LoadLevel()
        {
            if (_levelView == null)
            {
                _levelView = _resourceLoader.GetLevelVIew();
                _levelView.Construct(_screenBounds);
            }
            else
            {
                _levelView.Enable();
            }

        }

        protected override void OnGameOver()
        {
            _levelView.Disable();
        }
    }
}
