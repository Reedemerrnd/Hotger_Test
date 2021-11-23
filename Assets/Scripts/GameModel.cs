using Game.Utils;

namespace Game
{
    internal class GameModel
    {
        private SubscriptionProperty<GameState> _state;


        public SubscriptionProperty<GameState> State => _state;
        public float HorizontalSpeed { get; private set; }
        public float VerticalSpeed { get; private set; }
        public float SpeedIncreaseDelay { get; private set; }


        public GameModel(GameSettings gameSettings)
        {
            _state = new SubscriptionProperty<GameState>(gameSettings.InitialState);
            HorizontalSpeed = gameSettings.BaseHorizontalSpeed;
            VerticalSpeed = gameSettings.BaseVerticalSpeed;
            SpeedIncreaseDelay = gameSettings.SpeedIncreaseDelay;
        }


    }
}