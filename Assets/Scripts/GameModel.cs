using Game.Utils;

namespace Game
{
    internal class GameModel
    {
        private SubscriptionProperty<GameState> _state;

        private float _baseVerticalSpeed;

        public SubscriptionProperty<GameState> State => _state;
        public float HorizontalSpeed { get; private set; }
        public float VerticalSpeed { get; set; }
        public float SpeedIncreaseDelay { get; private set; }
        public float SpeedIncreaseRate { get; private set; }


        public GameModel(GameSettings gameSettings)
        {
            _state = new SubscriptionProperty<GameState>(gameSettings.InitialState);
            HorizontalSpeed = gameSettings.BaseHorizontalSpeed;
            _baseVerticalSpeed = gameSettings.BaseVerticalSpeed;
            VerticalSpeed = _baseVerticalSpeed;
            SpeedIncreaseDelay = gameSettings.SpeedIncreaseDelay;
            SpeedIncreaseRate = gameSettings.SpeedIncreaseRate;
        }

        public void Reset()
        {
            VerticalSpeed = _baseVerticalSpeed;
        }

    }
}