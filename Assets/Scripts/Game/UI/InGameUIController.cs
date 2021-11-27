namespace BallGame.Game.UI
{
    internal sealed class InGameUIController : BaseController
    {
        private readonly InGameUIView _inGameUI;
        private readonly GameModel _gameModel;


        public InGameUIController(InGameUIView inGameUI, GameModel gameModel)
        {
            _inGameUI = inGameUI;
            _gameModel = gameModel;
        }


        protected override void OnEnable() => _inGameUI.SubscribeOnButtonChange(SetButtonState);
        protected override void OnDisable()
        {
            _inGameUI.UnSubscribeOnButtonChange(SetButtonState);
            _gameModel.UpButtonHold = false;
        }

        private void SetButtonState(bool hold)
        {
            _gameModel.UpButtonHold = hold;
        }
    }
}
